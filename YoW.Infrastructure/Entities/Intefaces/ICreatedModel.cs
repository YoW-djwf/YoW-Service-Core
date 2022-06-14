namespace YoW.Infrastructure.Entities.Intefaces;

public interface ICreatedModel
{
  public DateTime CreatedTime { get; set; }
  public string CreatedBy { get; set; }
}