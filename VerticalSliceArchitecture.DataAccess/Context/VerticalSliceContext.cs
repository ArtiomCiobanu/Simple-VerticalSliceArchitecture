using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.DataAccess.EntityConfigurations;
using VerticalSliceArchitecture.Domain.Entities;

namespace VerticalSliceArchitecture.DataAccess.Context;

public class VerticalSliceContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public VerticalSliceContext(DbContextOptions<VerticalSliceContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
    }

}
