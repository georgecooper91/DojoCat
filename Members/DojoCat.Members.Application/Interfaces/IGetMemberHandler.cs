using DojoCat.Members.Common.DataContracts.Requests;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;
using DojoCat.Members.Common.User;

namespace DojoCat.Members.Application.Interfaces;

public interface IGetMemberHandler
{
    Task<Result<MemberDetailsResponse>> Handle(string userName, DojoCatUserProvider dojoProvider, CancellationToken cancellationToken);
}
