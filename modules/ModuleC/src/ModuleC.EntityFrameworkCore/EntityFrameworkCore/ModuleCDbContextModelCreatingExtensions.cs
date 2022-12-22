using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ModuleC.EntityFrameworkCore;

public static class ModuleCDbContextModelCreatingExtensions
{
    public static void ConfigureModuleC(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
