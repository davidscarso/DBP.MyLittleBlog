using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DBP.MyLittleBlog.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class MyLittleBlogDbContextFactory : IDesignTimeDbContextFactory<MyLittleBlogDbContext>
{
    public MyLittleBlogDbContext CreateDbContext(string[] args)
    {
        MyLittleBlogEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MyLittleBlogDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new MyLittleBlogDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DBP.MyLittleBlog.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
