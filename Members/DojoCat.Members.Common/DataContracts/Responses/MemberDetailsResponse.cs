namespace DojoCat.Members.Common.DataContracts.Responses;

public class MemberDetailsResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Grade { get; set; } = "white";
    public ContactDetailsDto ContactDetails { get; set; }
    public DateTimeOffset Joined { get; set; }
    public bool IsTeacher { get; set; }
    public bool ActiveMember { get; set; }

}
