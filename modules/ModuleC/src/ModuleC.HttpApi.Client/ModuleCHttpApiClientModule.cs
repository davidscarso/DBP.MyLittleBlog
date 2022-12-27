using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ModuleC;

[DependsOn(
    typeof(ModuleCApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ModuleCHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ModuleCApplicationContractsModule).Assembly,
            ModuleCRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleCHttpApiClientModule>();
        });

    }
}
