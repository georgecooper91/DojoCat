using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoCat.Members.Infrastructure.Models;

public class EmergencyContact
{
    [Key]
    [Column(TypeName="bigint")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long MemberId { get; set; }

    [ForeignKey(nameof(Id))]
    public virtual Member Member { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public long ContactDetailsId { get; set; }

    [ForeignKey(nameof(Id))]
    public virtual ContactDetails ContactDetails { get; set; }
}
