using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ModuleB.EntityFrameworkCore;

[ConnectionStringName(ModuleBDbProperties.ConnectionStringName)]
public interface IModuleBDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
