using Volo.Abp.Modularity;

namespace ModuleB;

[DependsOn(
    typeof(ModuleBApplicationModule),
    typeof(ModuleBDomainTestModule)
    )]
public class ModuleBApplicationTestModule : AbpModule
{

}
