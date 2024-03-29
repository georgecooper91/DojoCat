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
    private readonly DojoCatUserProvider _dojoProvider;


    public MembersController(IMapper mapper,
        INewMemberHandler newMemberHandler,
        DojoCatUserProvider dojoProvider,
        ILogger<MembersController> logger)
    {
        _mapper = mapper;
        _logger = logger;
        _dojoProvider = dojoProvider;
        _newMemberHandler = newMemberHandler;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterMember(MemberRequest request, CancellationToken cancellationToken)
    {
        _logger.LogTrace("Receieved request to create user with {username}", request.Username);

        var command = new NewMemberCommand(_mapper.Map<Member>(request));
        Result<MemberResponse> result = await _newMemberHandler.Handle(command, cancellationToken);
        
        return result.IsSuccess ? CreatedAtAction(nameof(RegisterMember), result.Value) 
            : this.ReturnError(result);
    }

}
