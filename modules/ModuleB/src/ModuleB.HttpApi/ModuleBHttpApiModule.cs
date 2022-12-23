using Localization.Resources.AbpUi;
using ModuleB.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleB;

[DependsOn(
    typeof(ModuleBApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ModuleBHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ModuleBHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ModuleBResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
