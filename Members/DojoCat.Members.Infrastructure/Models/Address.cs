using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoCat.Members.Infrastructure.Models;

public class Address
{
    [Key]
    [Column(TypeName="bigint")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public long MemberId { get; set; }

    [ForeignKey(nameof(Id))]
    public virtual Member Member { get; set; }

    [Required]
    public string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    [Required]
    public string City { get; set; }

    public string? Region { get; set; }

    [Required]
    public string PostCode { get; set; }
}