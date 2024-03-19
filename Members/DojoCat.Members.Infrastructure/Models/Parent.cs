using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoCat.Members.Infrastructure.Models;

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

    public DateTimeOffset Updated { get; set; }

    public bool DeleteParent { get; set; } = false;

    [Required]
    public List<Member> Children { get; set; } = new List<Member>();

}
