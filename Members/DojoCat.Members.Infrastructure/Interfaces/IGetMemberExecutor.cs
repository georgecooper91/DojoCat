using DojoCat.Members.Infrastructure.Models;

namespace DojoCat.Members.Infrastructure.Interfaces;

public interface IGetMemberExecutor
{
    Task<Member> Execute(string username, CancellationToken cancellationToken);
}
