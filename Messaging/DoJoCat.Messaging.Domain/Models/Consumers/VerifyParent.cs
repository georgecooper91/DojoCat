namespace DojoCat.Members.Common.DataContracts.Messaging;

public class VerifyParent
{
    public string RoutingKey { get; } = "dojocat.members.validateparent";
    public string MemberName { get; set; }
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    public long InternationalCallingCode { get; set; }
    public string PreferedMethodOfContact { get; set; }
    public string ParentName { get; set; }
}
