using ModuleC.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ModuleC;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ModuleCEntityFrameworkCoreTestModule)
    )]
public class ModuleCDomainTestModule : AbpModule
{

}
