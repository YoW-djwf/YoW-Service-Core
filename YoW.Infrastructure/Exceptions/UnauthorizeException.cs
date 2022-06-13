namespace YoW.Infrastructure.Exceptions
{
  public class UnauthorizeException : AppException
  {
    public UnauthorizeException() : base(401, "Unauthorized") { }
  }
}
