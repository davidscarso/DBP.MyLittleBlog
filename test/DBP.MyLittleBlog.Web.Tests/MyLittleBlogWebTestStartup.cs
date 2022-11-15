using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace DBP.MyLittleBlog;

public class MyLittleBlogWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<MyLittleBlogWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
