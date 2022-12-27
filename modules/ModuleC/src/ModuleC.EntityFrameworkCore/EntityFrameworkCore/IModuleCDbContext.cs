using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ModuleC.EntityFrameworkCore;

[ConnectionStringName(ModuleCDbProperties.ConnectionStringName)]
public interface IModuleCDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
