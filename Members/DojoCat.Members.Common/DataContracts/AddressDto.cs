namespace DojoCat.Members.Common.DataContracts;

public class AddressDto
{
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string? Region { get; set; }
    public string PostCode { get; set; }
}
