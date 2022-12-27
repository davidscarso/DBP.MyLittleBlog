using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using ModuleA;
using ModuleB;
using ModuleC;

namespace DBP.MyLittleBlog;

[DependsOn(
    typeof(MyLittleBlogDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(MyLittleBlogApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
[DependsOn(typeof(ModuleAApplicationModule))]
    [DependsOn(typeof(ModuleBApplicationModule))]
    [DependsOn(typeof(ModuleCApplicationModule))]
    public class MyLittleBlogApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<MyLittleBlogApplicationModule>();
        });
    }
}
