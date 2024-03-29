using AutoMapper;
using DojoCat.Members.Infrastructure.Database;
using DojoCat.Members.Infrastructure.Interfaces;
using DojoCat.Members.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DojoCat.Members.Infrastructure.Queries;

public class GetMemberExecutor : IGetMemberExecutor
{
    private readonly MembersDbContext _database;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetMemberExecutor(MembersDbContext database, IMapper mapper, ILogger<GetMemberExecutor> logger)
    {
        _database = database;
        _mapper = mapper;
        _logger = logger; 
    }

    public async Task<Member> Execute(string username, CancellationToken cancellationToken)
    {
        return await _database.Members.Include(m => m.ContactDetails)
            .Include(m => m.Address)
            .Include(m => m.EmergencyContact)
                .ThenInclude(ec => ec.ContactDetails)
            .FirstOrDefaultAsync(m => m.Username == username, cancellationToken);
    }
}
