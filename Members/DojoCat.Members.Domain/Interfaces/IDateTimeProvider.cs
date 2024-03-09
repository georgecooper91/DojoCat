namespace DojoCat.Members.Domain.Interfaces;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
    DateTimeOffset Today { get; }
}
