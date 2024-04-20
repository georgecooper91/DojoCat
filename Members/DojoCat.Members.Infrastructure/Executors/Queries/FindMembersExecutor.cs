using AutoMapper;
using DojoCat.Members.Domain.Models;
using DojoCat.Members.Infrastructure.Database;
using DojoCat.Members.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DojoCat.Members.Infrastructure.Executors.Queries;

public class FindMembersExecutor : IFindMembersExecutor
{
    private readonly MembersDbContext _database;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public FindMembersExecutor(MembersDbContext database, IMapper mapper, ILogger<FindMembersExecutor> logger)
    {
        _database = database;
        _mapper = mapper;
        _logger = logger; 
    }

    public async Task<List<Member>> Execute(List<string> membersToFind, CancellationToken cancellationToken)
    {
        var members = await _database.Members.Where(e => membersToFind.Contains(e.Username))
            .Include(m => m.ContactDetails)
            .Include(m => m.Address)
            .Include(m => m.MemberParent)
            .Include(m => m.EmergencyContact)           
            .ToListAsync();
            
        return _mapper.Map<List<Member>>(members);
    }
}
