using Volo.Abp.Modularity;

namespace DBP.MyLittleBlog;

[DependsOn(
    typeof(MyLittleBlogApplicationModule),
    typeof(MyLittleBlogDomainTestModule)
    )]
public class MyLittleBlogApplicationTestModule : AbpModule
{

}
