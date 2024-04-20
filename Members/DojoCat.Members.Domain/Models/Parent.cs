namespace DojoCat.Members.Domain.Models;

public class Parent
{
    public long Id { get; set; } 
    public Guid ParentReference { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public DateTimeOffset Joined { get; set; }
    public DateTimeOffset Updated { get; set; }
    public ContactDetails ContactDetails { get; set; }
    public bool DeleteParent { get; set; } = false;
    public List<Member> Children { get; set; } = new List<Member>();
    public bool Verified { get; set; } = false;

}
