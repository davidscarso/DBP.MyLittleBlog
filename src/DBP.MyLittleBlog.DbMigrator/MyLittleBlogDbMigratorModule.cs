using DBP.MyLittleBlog.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace DBP.MyLittleBlog.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyLittleBlogEntityFrameworkCoreModule),
    typeof(MyLittleBlogApplicationContractsModule)
    )]
public class MyLittleBlogDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
