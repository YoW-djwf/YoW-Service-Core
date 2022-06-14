using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using YoW.Infrastructure.Entities;
using YoW.Infrastructure.Entities.Intefaces;
using YoW.Infrastructure.EntityFramework.EntitiesConfiguration;
using YoW.Infrastructure.Interfaces;
using YoW.Infrastructure.Timing;

namespace YoW.Infrastructure.EntityFramework
{
  public abstract class AppDbContextBase : DbContext
  {
    private IAuditService AuditService { get; set; }
    public AppDbContextBase(DbContextOptions options, IAuditService auditService) : base(options)
    {
      AuditService = auditService;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      foreach (var type in builder.Model.GetEntityTypes())
      {
        if (type.BaseType != null || !typeof(IDeletedModel).IsAssignableFrom(type.ClrType))
        {
          builder.Entity(type.ClrType)
            .HasQueryFilter(AddExtendFilter(type.ClrType, nameof(IDeletedModel.IsDeleted), false));
        }
        if (type.BaseType != null || !typeof(ITenancyModel).IsAssignableFrom(type.ClrType))
        {
          builder.Entity(type.ClrType)
            .HasQueryFilter(AddExtendFilter(type.ClrType, nameof(ITenancyModel.TenantId), AuditService.TenantId));
        }
    }
    }

    public override int SaveChanges()
    {
      ApplyDatabaseConcepts();
      return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      ApplyDatabaseConcepts();
      return base.SaveChangesAsync(cancellationToken);
    }

    private static LambdaExpression AddExtendFilter(Type type, string propName, object value)
    {
      var parameter = Expression.Parameter(type);
      var property = Expression.Property(parameter, propName);
      var falseConstant = Expression.Constant(value);
      var expression = Expression.Equal(property, falseConstant);

      return Expression.Lambda(expression, parameter);
    }

    private void ApplyDatabaseConcepts()
    {
      foreach (var entry in ChangeTracker.Entries())
      {
        MapState(entry).Invoke();
      }
    }

    private Action MapState(EntityEntry entry) => entry.State switch
    {
      EntityState.Added => () => SetCreationAuditProperties(entry.Entity),
      EntityState.Modified => () => SetModificationAuditProperties(entry.Entity),
      EntityState.Deleted => () => SetDeletionAuditProperties(entry),
      EntityState.Detached => () => { },
      EntityState.Unchanged => () => { },
      _ => () => throw new ArgumentOutOfRangeException(entry.State.ToString())
    };

    private void SetDeletionAuditProperties(EntityEntry entry)
    {
      if (entry.Entity is not IDeletedModel model)
      {
        return;
      }

      entry.State = EntityState.Unchanged;
      model.IsDeleted = true;
      model.DeletedTime = Clock.Now;
      model.DeletedBy = AuditService.UserName;
    }

    private void SetModificationAuditProperties(object entity)
    {
      if (entity is IUpdatedModel model)
      {
        model.UpdatedTime = Clock.Now;
        model.UpdatedBy = AuditService.UserName;
      }
    }

    private void SetCreationAuditProperties(object entity)
    {
      if (entity is ICreatedModel model)
      {
        model.CreatedTime = Clock.Now;
        model.CreatedBy = AuditService.UserName;
      }
      SetModificationAuditProperties(entity);
    }
  }
}