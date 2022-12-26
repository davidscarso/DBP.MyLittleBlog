using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ModuleB;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ModuleBDomainSharedModule)
)]
public class ModuleBDomainModule : AbpModule
{

}
