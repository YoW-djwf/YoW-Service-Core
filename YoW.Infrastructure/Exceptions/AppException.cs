using System;

namespace YoW.Infrastructure.Exceptions
{
  public class AppException : Exception
  {
    public int Status { get; internal set; }

    public AppException(int status, string message) : base(message) => Status = status;

    public AppException(string message) : base(message) { }
  }
}
