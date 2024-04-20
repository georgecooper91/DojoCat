using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Infrastructure.Executors;

public interface INewParentExecutor
{
    Task<long> Execute(Parent command, CancellationToken cancellationToken);
}
