using AutoMapper;
using DojoCat.Members.Application.Commands;
using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Application.Interfacess;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;
using DojoCat.Members.Domain.Exceptions;
using DojoCat.Members.Infrastructure.Executors;
using DojoCat.Members.Infrastructure.Interfaces;
using DojoCat.Messaging.DataContracts;
using Microsoft.Extensions.Logging;

namespace DojoCat.Members.Application.CommandHandlers;

public class NewParentHandler : INewParentHandler
{
    private readonly IFindMembersExecutor _findMembersExecutor;
    private readonly INewParentExecutor _newParentExecutor;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IAddMemberParentAssociationExecutor _addMemberParentAssociationExecutor;
    private readonly IMatchMembersToParents _matchMembersToParents;
    private readonly IMessageSender<VerifyParent> _messageSender;

    public NewParentHandler(IFindMembersExecutor findMembersExecutor,
        INewParentExecutor newParentExecutor,
        IMapper mapper,
        ILogger<NewParentHandler> logger,
        IAddMemberParentAssociationExecutor addParentMemberJunctionExecutor,
        IMatchMembersToParents matchMembersToParents,
        IMessageSender<VerifyParent> messageSender)
    {
        _findMembersExecutor = findMembersExecutor;
        _newParentExecutor = newParentExecutor;
        _logger = logger;
        _mapper = mapper;
        _addMemberParentAssociationExecutor = addParentMemberJunctionExecutor;
        _matchMembersToParents = matchMembersToParents;
        _messageSender = messageSender;
    }

    public async Task<Result<NewParentResponse>> Handle(NewParentCommand command, CancellationToken cancellationToken)
    {
        try {
            var children = await _findMembersExecutor.Execute(command.Parent.Children.Select(c => c.Username).ToList(), cancellationToken);
        
            var (matchedChildren, unmatchedChildren) = _matchMembersToParents.Match(children, command.Parent);
            
            // send message to service bus to get child's confirmation
            foreach (var child in matchedChildren)
            {
                var message = new VerifyParent
                {
                    MemberName = children[0].FirstName,
                    Email = children[0].ContactDetails.Email,
                    PhoneNumber = children[0].ContactDetails.PhoneNumber,
                    InternationalCallingCode = children[0].ContactDetails.InternationalCallingCode,
                    PreferedMethodOfContact = children[0].ContactDetails.PreferedMethodOfContact,
                    ParentName = command.Parent.FirstName + " " + command.Parent.LastName,
                };

                _messageSender.SendMessage(message, cancellationToken);
            }

            var id = await _newParentExecutor.Execute(command.Parent, cancellationToken);

            if(id == 0)
            {
                throw new Microsoft.EntityFrameworkCore.DbUpdateException("Failed to add new parent to db");
            }

            command.Parent.Id = id;

            var (memberParents, unmatched) = _matchMembersToParents.Match(children, command.Parent);

            if(memberParents.Count == 0)
            {
                return Result.Failure(new NewParentResponse(), GeneralErrors.PartialSuccess($"Successfully added parent with username {command.Parent.Username} " +
                    "to db but failed to make a match to your children with the details provided"));
            }

            var a = await _addMemberParentAssociationExecutor.Execute(memberParents, cancellationToken);
            
        } catch(Exception e)
        {
            _logger.LogError("Failed to add new parent to database: {error}", e);
            return Result.Failure(_mapper.Map<NewParentResponse>(command.Parent), GeneralErrors.InternalError);
        }

        _logger.LogTrace("Successfully added new parent to db with username {username}", command.Parent.Username);
        return Result.Success(_mapper.Map<NewParentResponse>(command.Parent));
    }
}
