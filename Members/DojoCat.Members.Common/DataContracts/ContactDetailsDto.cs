namespace DojoCat.Members.Common.DataContracts;

public class ContactDetailsDto
{
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    public long InternationalCallingCode { get; set; }
    public string PreferedMethodOfContact { get; set; }
}
