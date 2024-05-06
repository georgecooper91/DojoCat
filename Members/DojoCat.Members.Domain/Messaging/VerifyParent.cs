namespace DojoCat.Messaging.DataContracts;
public class VerifyParent : IBusMessage
{
    public string RoutingKey { get; } = "dojocat.members.validateparent";
    public string MemberName { get; set; }
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    public long InternationalCallingCode { get; set; }
    public string PreferedMethodOfContact { get; set; }
    public string ParentName { get; set; }
}
