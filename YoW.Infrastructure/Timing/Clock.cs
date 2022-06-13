using System;

namespace YoW.Infrastructure.Timing
{
  public static class Clock
  {
    private static IClockProvider _provider;

    public static IClockProvider Provider
    {
      get => _provider;
      set => _provider = value ?? throw new ApplicationException("Can not set Clock to null!");
    }

    public static DateTime Now => Provider.Now;

    public static DateTimeKind Kind => Provider.Kind;

    static Clock()
    {
      Provider = new UtcClockProvider();
    }

    public static DateTime? NormalizeNullable(DateTime? dateTime)
    {
      return Provider.NormalizeNullable(dateTime);
    }

    public static DateTime Normalize(DateTime dateTime)
    {
      return Provider.Normalize(dateTime);
    }

    public static object NormalizeObject(object @object)
    {
      return Provider.NormalizeObject(@object);
    }
  }
}