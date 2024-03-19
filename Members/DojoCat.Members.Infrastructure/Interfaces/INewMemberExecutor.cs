using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Infrastructure.Interfaces;

public interface INewMemberExecutor
{
    Task<int> Execute(Member command, CancellationToken cancellationToken);
}
