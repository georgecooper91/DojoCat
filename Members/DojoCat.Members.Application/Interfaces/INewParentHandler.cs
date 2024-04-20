using DojoCat.Members.Application.Commands;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;

namespace DojoCat.Members.Application.Interfaces;

public interface INewParentHandler
{
    Task<Result<NewParentResponse>> Handle(NewParentCommand command, CancellationToken cancellationToken);
}
