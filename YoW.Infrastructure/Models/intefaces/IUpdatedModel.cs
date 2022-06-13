using System;

namespace YoW.Infrastructure.Models.intefaces
{
  public interface IUpdatedModel
  {
    public DateTime UpdatedTime { get; set; }
    public string UpdatedBy { get; set; }
  }
}