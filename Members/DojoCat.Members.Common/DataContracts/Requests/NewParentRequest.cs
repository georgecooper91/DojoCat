namespace DojoCat.Members.Common.DataContracts.Requests;

public class NewParentRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public ContactDetailsDto ContactDetails { get; set; }
    public List<ChildClaim> Children { get; set; }
}
