using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ModuleB;

[DependsOn(
    typeof(ModuleBApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ModuleBHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ModuleBApplicationContractsModule).Assembly,
            ModuleBRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleBHttpApiClientModule>();
        });

    }
}
