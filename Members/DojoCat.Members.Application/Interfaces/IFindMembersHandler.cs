using DojoCat.Members.Common.Result;
using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Application.Interfaces;

public interface IFindMembersHandler
{
    Task<Result<List<Member>>> Handle(List<Member> membersToFind, CancellationToken cancellationToken);

}
