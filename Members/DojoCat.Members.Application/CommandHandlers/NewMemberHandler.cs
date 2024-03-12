using DojoCat.Members.Application.Commands;
using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;

namespace DojoCat.Members.Application.CommandHandlers;

public class NewMemberHandler : INewMemberHandler
{
    public async Task<Result<MemberResponse>> Handle(NewMemberCommand command, CancellationToken cancellationToken)
    {
        
        throw new NotImplementedException();
    }
}
