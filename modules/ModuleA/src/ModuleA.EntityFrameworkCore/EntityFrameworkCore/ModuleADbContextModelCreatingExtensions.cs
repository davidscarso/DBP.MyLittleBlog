using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModuleA.EntityFrameworkCore;

public static class ModuleADbContextModelCreatingExtensions
{
    public static void ConfigureModuleA(
        this ModelBuilder builder,
        Action<ModuleAModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));
        var options = new ModuleAModelBuilderConfigurationOptions(
              ModuleADbProperties.DbTablePrefix,
              ModuleADbProperties.DbSchema
          );

        builder.Entity<TodoOne>(b =>
        {
            b.ToTable(options.TablePrefix + "TodoOnes", options.Schema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });
    }
}
