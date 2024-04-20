using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoCat.Members.Infrastructure.Models;

public class MemberParent
{
    [Key]
    public long id { get; set; }
    
    public long MemberId { get; set; }
    [ForeignKey(nameof(MemberId))]
    [Column(Order = 1)]
    public virtual Member Member { get; set; }
    
    public long ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    [Column(Order = 2)]
    public virtual Parent Parent { get; set; }

}
