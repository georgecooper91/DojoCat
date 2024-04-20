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
public class ParentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly DojoCatUserProvider _dojoProvider;
    private readonly ILogger<ParentsController> _logger;
    private readonly INewParentHandler _newMemberHandler;

    public ParentsController(IMapper mapper,
        DojoCatUserProvider dojoProvider,
        ILogger<ParentsController> logger,
        INewParentHandler newMemberHandler)
    {
        _mapper = mapper;
        _dojoProvider = dojoProvider;
        _logger = logger;
        _newMemberHandler = newMemberHandler;   
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterMember(NewParentRequest request, CancellationToken cancellationToken)
    {
        _logger.LogTrace("Receieved request to create parent with username {username}", request.Username);

        var command = new NewParentCommand(_mapper.Map<Parent>(request));
        Result<NewParentResponse> result = await _newMemberHandler.Handle(command, cancellationToken);
        
        return result.IsSuccess ? CreatedAtAction(nameof(RegisterMember), result.Value) 
            : this.ReturnError(result);
    }

}
