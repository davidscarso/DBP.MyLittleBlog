using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ModuleA;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ModuleAInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleAInstallerModule>();
        });
    }
}
