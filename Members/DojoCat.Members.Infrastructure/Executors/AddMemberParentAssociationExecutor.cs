using AutoMapper;
using DojoCat.Members.Infrastructure.Database;
using DojoCat.Members.Infrastructure.Interfaces;
using DojoCat.Members.Infrastructure.Models;
using Microsoft.Extensions.Logging;

namespace DojoCat.Members.Infrastructure.Executors;

public class AddMemberParentAssociationExecutor : IAddMemberParentAssociationExecutor
{
    private readonly MembersDbContext _database;
    private readonly ILogger _logger;

    public AddMemberParentAssociationExecutor(MembersDbContext database, 
        ILogger<AddMemberParentAssociationExecutor> logger)
    {
        _database = database;
        _logger = logger; 
    }

    public async Task<List<MemberParent>> Execute(List<MemberParent> junctionIds, CancellationToken cancellationToken)
    {        
        await _database.AddRangeAsync(junctionIds, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);

        return junctionIds;
    }
}
