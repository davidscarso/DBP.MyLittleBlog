using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ModuleB;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ModuleBInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleBInstallerModule>();
        });
    }
}
