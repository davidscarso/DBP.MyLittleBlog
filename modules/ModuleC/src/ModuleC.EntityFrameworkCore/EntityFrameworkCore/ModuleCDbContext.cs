using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ModuleC.EntityFrameworkCore;

[ConnectionStringName(ModuleCDbProperties.ConnectionStringName)]
public class ModuleCDbContext : AbpDbContext<ModuleCDbContext>, IModuleCDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ModuleCDbContext(DbContextOptions<ModuleCDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureModuleC();
    }
}
