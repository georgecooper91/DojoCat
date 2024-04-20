using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoCat.Members.Infrastructure.Models;

public class ContactDetails
{
    [Key]
    [Column(TypeName="bigint")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? MemberId { get; set; }

    [ForeignKey(nameof(MemberId))]
    public virtual Member Member { get; set; }

    [Required]
    public string Email { get; set; }

    public long? PhoneNumber { get; set; }

    public long? InternationalCallingCode { get; set; }

    [Required]
    public string PreferedMethodOfContact { get; set; }

    public long? EmergencyContactId { get; set; }

    [ForeignKey(nameof(EmergencyContactId))]
    public virtual EmergencyContact EmergencyContact { get; set; }

    public long? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))]
    public virtual Parent? Parent { get; set; }
}