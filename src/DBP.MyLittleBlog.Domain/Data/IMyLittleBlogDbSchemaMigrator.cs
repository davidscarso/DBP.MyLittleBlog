using System.Threading.Tasks;

namespace DBP.MyLittleBlog.Data;

public interface IMyLittleBlogDbSchemaMigrator
{
    Task MigrateAsync();
}
