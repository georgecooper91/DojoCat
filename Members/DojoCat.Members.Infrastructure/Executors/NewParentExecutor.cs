using AutoMapper;
using DojoCat.Members.Domain.Models;
using DojoCat.Members.Infrastructure.Database;
using dbParent = DojoCat.Members.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using DojoCat.Members.Domain.Interfaces;

namespace DojoCat.Members.Infrastructure.Executors;

public class NewParentExecutor : INewParentExecutor
{
    private readonly MembersDbContext _database;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IDateTimeProvider _dateTimeProvider;

    public NewParentExecutor(MembersDbContext database, 
        IMapper mapper, 
        ILogger<NewParentExecutor> logger,
        IDateTimeProvider dateTimeProvider)
    {
        _database = database;
        _mapper = mapper;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<long> Execute(Parent parent, CancellationToken cancellationToken)
    {
        var parentToAdd = _mapper.Map<dbParent.Parent>(parent);
        parentToAdd.Updated = _dateTimeProvider.UtcNow;
        parentToAdd.Joined = _dateTimeProvider.UtcNow;
        parentToAdd.ParentReference = Guid.NewGuid();
        
        _database.Add(parentToAdd);
        await _database.SaveChangesAsync(cancellationToken);

        return parentToAdd.Id;
    }
}
