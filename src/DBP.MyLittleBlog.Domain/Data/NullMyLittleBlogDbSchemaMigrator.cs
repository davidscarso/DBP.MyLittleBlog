using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DBP.MyLittleBlog.Data;

/* This is used if database provider does't define
 * IMyLittleBlogDbSchemaMigrator implementation.
 */
public class NullMyLittleBlogDbSchemaMigrator : IMyLittleBlogDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
