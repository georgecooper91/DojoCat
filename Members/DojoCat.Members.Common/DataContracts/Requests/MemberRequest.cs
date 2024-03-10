namespace DojoCat.Members.Common.DataContracts.Requests;

public class MemberRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Grade { get; set; } = "white";
    public Address Address { get; set; }
    public ContactDetails ContactDetails { get; set; }
    public EmergencyContact EmergencyContact { get; set; }
}
