using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ModuleC;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ModuleCInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleCInstallerModule>();
        });
    }
}
