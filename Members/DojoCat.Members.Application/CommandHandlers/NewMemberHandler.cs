using DojoCat.Members.Application.Commands;
using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;
using DojoCat.Members.Domain.Errors;
using DojoCat.Members.Domain.Interfaces;
using DojoCat.Members.Domain.Models;
using AutoMapper;
using DojoCat.Members.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using DojoCat.Members.Infrastructure.Interfaces;


namespace DojoCat.Members.Application.CommandHandlers;

public class NewMemberHandler : INewMemberHandler
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;
    private readonly INewMemberExecutor _newMemberExecutor;
    private readonly ILogger _logger;

    public NewMemberHandler(IDateTimeProvider dateTimeProvider,
        IMapper mapper,
        INewMemberExecutor newMemberExecutor,
        ILogger<NewMemberHandler> logger)
    {
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
        _newMemberExecutor = newMemberExecutor;
        _logger = logger;
    }

    public async Task<Result<MemberResponse>> Handle(NewMemberCommand command, CancellationToken cancellationToken)
    {
        if(await UsernameAlreadyTaken())
        {
            _logger.LogTrace("Username {username} already in use", command.Member.Username);
            return Result.Failure(_mapper.Map<MemberResponse>(command.Member), UserErrors.UsernameAlreadyInUse);
        }

        SetMemberDetails(command.Member);

        try {
            var nSaved = await _newMemberExecutor.Execute(command.Member, cancellationToken);

            if(nSaved < 1)
            {
                _logger.LogWarning("New member not saved to db with username {}", command.Member.Username);
                return Result.Failure(_mapper.Map<MemberResponse>(command.Member), GeneralErrors.InternalError);
            }

        } catch (Exception e)
        {
            _logger.LogError("Failed to add new member to database: {error}", e);
            return Result.Failure(_mapper.Map<MemberResponse>(command.Member), GeneralErrors.InternalError);
        }
        
        _logger.LogTrace("Successfully added new member to db with username {username}", command.Member.Username);
        return Result.Success(_mapper.Map<MemberResponse>(command.Member));
    }

    private async Task<bool> UsernameAlreadyTaken()
    {
        //TODO: implement this with auth service
        return false;
    }

    private void SetMemberDetails(Member member)
    {
        var now = _dateTimeProvider.UtcNow;
        member.Joined = now;
        member.Updated = now;
        member.UserReference = Guid.NewGuid();
    }
}
