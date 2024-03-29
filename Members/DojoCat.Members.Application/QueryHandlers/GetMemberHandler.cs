using AutoMapper;
using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Common.DataContracts.Requests;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;
using DojoCat.Members.Common.User;
using Microsoft.Extensions.Logging;
using DojoCat.Members.Infrastructure.Interfaces;
using DojoCat.Members.Domain.Exceptions;
using DojoCat.Members.Infrastructure.Models;
using DojoCat.Members.Domain.Errors;


namespace DojoCat.Members.Application.QueryHandlers;

public class GetMemberHandler : IGetMemberHandler
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IGetMemberExecutor _getMemberExecutor;

    public GetMemberHandler(ILogger<GetMemberHandler> logger,
        IMapper mapper,
        IGetMemberExecutor getMemberExecutor)
    {
        _mapper = mapper;
        _logger = logger;
        _getMemberExecutor = getMemberExecutor;
    }

    public async Task<Result<MemberDetailsResponse>> Handle(string userName, DojoCatUserProvider dojoProvider, CancellationToken cancellationToken)
    {
        Member member;

        try {

            member = await _getMemberExecutor.Execute(userName, cancellationToken);

            if(member is null)
            {
                _logger.LogTrace("Member with username {username} not found in the db", userName);
                return Result.Failure(new MemberDetailsResponse(), UserErrors.UserNotFound);
            }
            
        } catch(Exception e)
        {
            _logger.LogError("Failed to get member {member} from the db due to: {e}", userName, e);
            return Result.Failure(new MemberDetailsResponse(), GeneralErrors.InternalError);
        }

        _logger.LogInformation("Successfully got member {member} from the db", userName);
        return Result.Success(_mapper.Map<MemberDetailsResponse>(member));
    }
}
