namespace HXR.Utilities.DateTime;

using System;

public interface IDateTimeProvider
{
    DateTime DateTimeNow { get; }
}
