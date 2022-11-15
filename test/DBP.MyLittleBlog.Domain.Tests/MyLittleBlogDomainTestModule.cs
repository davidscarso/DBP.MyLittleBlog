using DBP.MyLittleBlog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DBP.MyLittleBlog;

[DependsOn(
    typeof(MyLittleBlogEntityFrameworkCoreTestModule)
    )]
public class MyLittleBlogDomainTestModule : AbpModule
{

}
