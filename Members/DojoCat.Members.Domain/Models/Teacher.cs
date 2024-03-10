namespace DojoCat.Members.Domain.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public DateTimeOffset BecamTeacher { get; set; }
    public DateTimeOffset StoppedAsTeacher { get; set; }
    public DateTimeOffset Updated { get; set; }
}
