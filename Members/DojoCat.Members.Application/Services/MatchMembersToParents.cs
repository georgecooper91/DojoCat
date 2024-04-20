using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Domain.Models;
using memberParent = DojoCat.Members.Infrastructure.Models;


namespace DojoCat.Members.Application.Services;

public class MatchMembersToParents : IMatchMembersToParents
{

    public MatchMembersToParents()
    {
        
    }

    public (List<memberParent.MemberParent>, List<Member>) Match(IEnumerable<Member> members, Parent parent)
    {
        List<memberParent.MemberParent> memberParents = new List<memberParent.MemberParent>();
        List<Member> unmatchedMembers = new List<Member>();

        var orderedMembers = members.OrderByDescending(m => m.DateOfBirth)
            .ThenByDescending(m => m.FirstName)
            .ToList();

        var orderedParentMembers = parent.Children.OrderByDescending(m => m.DateOfBirth)
            .ThenByDescending(m => m.FirstName)
            .ToList();

        for(var i = 0; i < orderedParentMembers.Count(); i++)
        {
            if(IsParent(orderedMembers[i], orderedParentMembers[i]))
            {
                memberParents.Add(new memberParent.MemberParent { MemberId = orderedMembers[i].Id, ParentId = parent.Id });
            } else 
            {
                unmatchedMembers.Add(orderedParentMembers[i]);
            }
        }

        return (memberParents, unmatchedMembers);
    }

    private Func<Member, Member, bool> IsParent = (member, parentMember) => 
    {
        if(parentMember.FirstName.Equals(member.FirstName) && parentMember.LastName.Equals(member.LastName)
            && parentMember.DateOfBirth.Date == member.DateOfBirth.Date)
        {
            return true;
        } else 
        {
            return false;
        }
    };
}
