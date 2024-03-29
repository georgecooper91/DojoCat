using AutoMapper;
using DojoCat.Members.Api.Extensions;
using DojoCat.Members.Application.Commands;
using DojoCat.Members.Application.Interfaces;
using DojoCat.Members.Common.DataContracts.Requests;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;
using DojoCat.Members.Common.User;
using DojoCat.Members.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DojoCat.Members.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<MembersController> _logger;
    private readonly INewMemberHandler _newMemberHandler;
    private readonly IGetMemberHandler _getMemberHandler;
    private readonly DojoCatUserProvider _dojoProvider;


    public MembersController(IMapper mapper,
        INewMemberHandler newMemberHandler,
        IGetMemberHandler getMemberHandler,
        DojoCatUserProvider dojoProvider,
        ILogger<MembersController> logger)
    {
        _mapper = mapper;
        _logger = logger;
        _dojoProvider = dojoProvider;
        _newMemberHandler = newMemberHandler;
        _getMemberHandler = getMemberHandler;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterMember(MemberRequest request, CancellationToken cancellationToken)
    {
        _logger.LogTrace("Receieved request to create user with username {username}", request.Username);

        var command = new NewMemberCommand(_mapper.Map<Member>(request));
        Result<MemberResponse> result = await _newMemberHandler.Handle(command, cancellationToken);
        
        return result.IsSuccess ? CreatedAtAction(nameof(RegisterMember), result.Value) 
            : this.ReturnError(result);
    }

    [HttpGet("getmemberdetails/{username}")]
    public async Task<IActionResult> GetMemberDetails([FromRoute] string username, CancellationToken cancellationToken)
    {
        _logger.LogTrace("Receieved request to get member details with username {username}", username);

        Result<MemberDetailsResponse> result = await _getMemberHandler.Handle(username, _dojoProvider, cancellationToken);
        
        return result.IsSuccess ? CreatedAtAction(nameof(GetMemberDetails), result.Value) 
            : this.ReturnError(result);
    }

}
