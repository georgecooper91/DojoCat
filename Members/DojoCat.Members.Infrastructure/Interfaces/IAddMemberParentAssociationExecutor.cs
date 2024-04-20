using DojoCat.Members.Infrastructure.Models;

namespace DojoCat.Members.Infrastructure.Interfaces;

public interface IAddMemberParentAssociationExecutor
{
    Task<List<MemberParent>> Execute(List<MemberParent> entities, CancellationToken cancellationToken);
}
