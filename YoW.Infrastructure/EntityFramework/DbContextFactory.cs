using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using YoW.Infrastructure.Interfaces;

namespace YoW.Infrastructure.EntityFramework;

public interface IDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  DbContext DbContext { get; }
}

public class DbContextFactory : IDesignTimeDbContextFactory
{
  private readonly IAuditService auditService;
  private DbContext _dbContext;
  private object _lockDbContext = new();

  public DbContext DbContext
  {
    get
    {
      if (_dbContext == null)
      {
        lock (_lockDbContext)
        {
          _dbContext = CreateDbContext(Array.Empty<string>());
        }
      }

      return _dbContext;
    }
  }

  public DbContextFactory(IAuditService auditService)
  {
    this.auditService = auditService;
  }

  public DbContextFactory()
  {
    auditService = new AuditService
    {
      UserName = "System"
    };
  }

  public AppDbContext CreateDbContext(string[] args)
  {
    var builder = new DbContextOptionsBuilder<AppDbContext>();

    var configuration = AppConfigurations.Get(DirectoryFinder.CalculateContentRootFolder());

    builder.UseAppDbContext(configuration);

    return new AppDbContext(builder.Options, auditService);
  }
}