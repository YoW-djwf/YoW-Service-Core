using System;

namespace YoW.Infrastructure.Entities.Intefaces
{
  public interface IUpdatedModel
  {
    public DateTime UpdatedTime { get; set; }
    public string UpdatedBy { get; set; }
  }
}