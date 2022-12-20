using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ModuleA;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ModuleAHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ModuleAConsoleApiClientModule : AbpModule
{

}
