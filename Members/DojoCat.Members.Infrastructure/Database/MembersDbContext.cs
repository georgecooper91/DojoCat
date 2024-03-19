using DojoCat.Members.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DojoCat.Members.Infrastructure.Database;

public class MembersDbContext : DbContext
{
    public MembersDbContext(DbContextOptions<MembersDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
}