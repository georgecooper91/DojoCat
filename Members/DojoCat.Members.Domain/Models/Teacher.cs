namespace DojoCat.Members.Domain.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public List<Class> Classes { get; set; } = new List<Class>();
    public DateTimeOffset BecamTeacher { get; set; }
    public DateTimeOffset StoppedAsTeacher { get; set; }
    public DateTimeOffset Updated { get; set; }
}
