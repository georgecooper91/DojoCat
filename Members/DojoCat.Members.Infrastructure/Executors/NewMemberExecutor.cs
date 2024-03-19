using AutoMapper;
using DojoCat.Members.Domain.Models;
using DojoCat.Members.Infrastructure.Database;
using DojoCat.Members.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;


namespace DojoCat.Members.Infrastructure.Executors;

public class NewMemberExecutor : INewMemberExecutor
{
    private readonly MembersDbContext _database;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public NewMemberExecutor(MembersDbContext database,
        IMapper mapper,
        ILogger<NewMemberExecutor> logger)
    {
        _database = database;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Execute(Member member, CancellationToken cancellationToken)
    {
        var memberToAdd = _mapper.Map<Models.Member>(member);
        _database.Add(memberToAdd);
        var n = await _database.SaveChangesAsync(cancellationToken);

        return n;
    }
}
