using DojoCat.Members.Domain.Models;
using memberParent = DojoCat.Members.Infrastructure.Models;

namespace DojoCat.Members.Application.Interfaces;

public interface IMatchMembersToParents
{
    (List<memberParent.MemberParent>, List<Member>) Match(IEnumerable<Member> members, Parent parent);
}
