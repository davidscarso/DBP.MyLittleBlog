using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModuleB.EntityFrameworkCore;

public static class ModuleBDbContextModelCreatingExtensions
{
    public static void ConfigureModuleB(
        this ModelBuilder builder,
        Action<ModuleBModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));
        var options = new ModuleBModelBuilderConfigurationOptions(
            ModuleBDbProperties.DbTablePrefix,
            ModuleBDbProperties.DbSchema
        );

        builder.Entity<EntityB>(b =>
        {
            b.ToTable(options.TablePrefix + "EntityBs", options.Schema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });
    }
}
