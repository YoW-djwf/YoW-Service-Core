using System;

namespace YoW.Infrastructure.Models.intefaces
{
  public interface ICreatedModel
  {
    public DateTime CreatedTime { get; set; }
    public string CreatedBy { get; set; }
  }
}