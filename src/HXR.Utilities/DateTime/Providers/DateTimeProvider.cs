namespace HXR.Utilities.DateTime.Providers;

using System;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime DateTimeNow => DateTime.Now;
}
