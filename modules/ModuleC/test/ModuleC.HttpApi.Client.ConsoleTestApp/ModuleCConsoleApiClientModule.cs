using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ModuleC;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ModuleCHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ModuleCConsoleApiClientModule : AbpModule
{

}
