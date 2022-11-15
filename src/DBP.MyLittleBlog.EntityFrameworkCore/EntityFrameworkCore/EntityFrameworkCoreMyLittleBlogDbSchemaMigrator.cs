using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DBP.MyLittleBlog.Data;
using Volo.Abp.DependencyInjection;

namespace DBP.MyLittleBlog.EntityFrameworkCore;

public class EntityFrameworkCoreMyLittleBlogDbSchemaMigrator
    : IMyLittleBlogDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMyLittleBlogDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MyLittleBlogDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MyLittleBlogDbContext>()
            .Database
            .MigrateAsync();
    }
}
