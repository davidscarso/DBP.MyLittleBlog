using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DBP.MyLittleBlog.BlogPosts;
using DBP.MyLittleBlog.CustomRepositories;
using ModuleA.EntityFrameworkCore;
using ModuleB.EntityFrameworkCore;

namespace DBP.MyLittleBlog.EntityFrameworkCore;

[DependsOn(
    typeof(MyLittleBlogDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
[DependsOn(typeof(ModuleAEntityFrameworkCoreModule))]
    [DependsOn(typeof(ModuleBEntityFrameworkCoreModule))]
    public class MyLittleBlogEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        MyLittleBlogEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MyLittleBlogDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);

            options.AddRepository<BlogPost, BlogPostRepository>();

        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also MyLittleBlogMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();

        });

        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<BlogPosts.BlogPost>(orderOptions =>
                orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.Comments));
        });

    }
}
