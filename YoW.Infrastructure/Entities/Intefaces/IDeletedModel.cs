using System;

namespace YoW.Infrastructure.Entities.Intefaces
{
  public interface IDeletedModel
  {
    public bool IsDeleted { get; set; }
    public DateTime? DeletedTime { get; set; }
    public string DeletedBy { get; set; }
  }
}