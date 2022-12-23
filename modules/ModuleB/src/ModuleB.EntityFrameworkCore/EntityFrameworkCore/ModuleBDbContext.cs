using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ModuleB.EntityFrameworkCore;

[ConnectionStringName(ModuleBDbProperties.ConnectionStringName)]
public class ModuleBDbContext : AbpDbContext<ModuleBDbContext>, IModuleBDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ModuleBDbContext(DbContextOptions<ModuleBDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureModuleB();
    }
}
