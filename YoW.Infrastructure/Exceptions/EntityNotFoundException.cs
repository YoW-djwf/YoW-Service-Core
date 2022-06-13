namespace YoW.Infrastructure.Exceptions
{
  public class EntityNotFoundException : AppException
  {
    public EntityNotFoundException(string message) : base(404, message) { }
  }
}
