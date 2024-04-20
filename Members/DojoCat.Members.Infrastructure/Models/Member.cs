using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DojoCat.Members.Infrastructure.Models;

[Index(nameof(Username), IsUnique = true)]
public class Member
{
    [Key]
    [Column(TypeName="bigint")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public Guid UserReference { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Grade { get; set; } = "white";

    [Required]
    public Address Address { get; set; }

    [Required]
    public ContactDetails ContactDetails { get; set; }

    [Required]
    public ICollection<EmergencyContact> EmergencyContact { get; set; }

    [Required]
    public DateTimeOffset Joined { get; set; }

    [Required]
    public DateTimeOffset Updated { get; set; }

    public bool IsTeacher { get; set; }

    public bool ActiveMember { get; set; }

    public bool DeleteMember { get; set; }

    public List<MemberParent>? MemberParent { get; set; }
}
