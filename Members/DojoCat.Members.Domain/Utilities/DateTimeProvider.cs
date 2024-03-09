using DojoCat.Members.Domain.Interfaces;

namespace DojoCat.Members.Domain.Utilities;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    public DateTimeOffset Today => UtcNow.Date;
}
