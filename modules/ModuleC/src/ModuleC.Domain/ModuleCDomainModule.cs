using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ModuleC;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ModuleCDomainSharedModule)
)]
public class ModuleCDomainModule : AbpModule
{

}
