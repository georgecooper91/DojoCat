using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DojoCat.Members.Infrastructure.Models;

[Index(nameof(Username), IsUnique = true)]
public class Parent
{
    [Key]
    [Column(TypeName="bigint")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public Guid ParentReference { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    public DateTimeOffset Joined { get; set; }

    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset Updated { get; set; }

    public bool DeleteParent { get; set; } = false;

    [Required]
    public List<MemberParent> MemberParent { get; set; }

    public bool Verified { get; set; }
}
