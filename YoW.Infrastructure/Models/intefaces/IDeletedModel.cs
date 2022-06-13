using System;

namespace YoW.Infrastructure.Models.intefaces
{
  public interface IDeletedModel
  {
    public bool IsDeleted { get; set; }
    public DateTime? DeletedTime { get; set; }
    public string DeletedBy { get; set; }
  }
}