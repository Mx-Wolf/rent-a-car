using Microsoft.EntityFrameworkCore;

namespace Esx.Integration;
public class MemoryDbContext
    (DbContextOptions<MemoryDbContext> options) 
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(IntegrationAssembley.Reference);
    }
}
