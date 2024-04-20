using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Infrastructure.Interfaces;

public interface IFindMembersExecutor
{
    Task<List<Member>> Execute(List<string> membersToFind, CancellationToken cancellationToken);

}
