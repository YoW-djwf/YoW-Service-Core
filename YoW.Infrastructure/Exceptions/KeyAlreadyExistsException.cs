namespace YoW.Infrastructure.Exceptions
{
  public class KeyAlreadyExistsException : AppException
  {
    public KeyAlreadyExistsException(string keyName) : base($"{keyName} already exists in the System")
    {
    }
  }
}
