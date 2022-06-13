using System;

namespace YoW.Infrastructure.Timing
{
  public class UtcClockProvider : IClockProvider
  {
    public DateTime Now => DateTime.UtcNow;

    public DateTimeKind Kind => DateTimeKind.Utc;

    public DateTime? NormalizeNullable(DateTime? dateTime)
    {
      if (!dateTime.HasValue)
      {
        return null;
      }

      switch (dateTime.Value.Kind)
      {
        case DateTimeKind.Unspecified:
          return DateTime.SpecifyKind(dateTime.Value, DateTimeKind.Utc);

        case DateTimeKind.Local:
          return dateTime.Value.ToUniversalTime();

        case DateTimeKind.Utc:
          return dateTime;

        default:
          return dateTime;
      }
    }

    public DateTime Normalize(DateTime dateTime)
    {
      switch (dateTime.Kind)
      {
        case DateTimeKind.Unspecified:
          return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

        case DateTimeKind.Local:
          return dateTime.ToUniversalTime();

        case DateTimeKind.Utc:
          return dateTime;

        default:
          return dateTime;
      }
    }

    public object NormalizeObject(object @object)
    {
      if (@object is DateTime d)
      {
        return Normalize(d);
      }

      return @object;
    }
  }
}