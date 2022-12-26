using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ModuleB;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ModuleBHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ModuleBConsoleApiClientModule : AbpModule
{

}
