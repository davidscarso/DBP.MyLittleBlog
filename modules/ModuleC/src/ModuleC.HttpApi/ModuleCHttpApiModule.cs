using Localization.Resources.AbpUi;
using ModuleC.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleC;

[DependsOn(
    typeof(ModuleCApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ModuleCHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ModuleCHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ModuleCResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
