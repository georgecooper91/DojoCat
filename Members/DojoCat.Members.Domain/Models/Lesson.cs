using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Domain;

public class Lesson
{
    public Guid Id { get; set; }
    public TimeSpan Time { get; set; }
    public Teacher Teacher { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Updated { get; set; }
    public bool ActiveLesson { get; set; } = true;
    public bool StoppedLesson { get; set; } = false;
}
