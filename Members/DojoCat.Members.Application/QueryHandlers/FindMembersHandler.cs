using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Common.Result;
using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Application.QueryHandlers;

public class FindMembersHandler : IFindMembersHandler
{
    public Task<Result<List<Member>>> Handle(List<Member> membersToFind, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
