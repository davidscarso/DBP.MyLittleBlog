using Volo.Abp.Modularity;

namespace ModuleC;

[DependsOn(
    typeof(ModuleCApplicationModule),
    typeof(ModuleCDomainTestModule)
    )]
public class ModuleCApplicationTestModule : AbpModule
{

}
