using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DBP.MyLittleBlog.Web;

[Dependency(ReplaceServices = true)]
public class MyLittleBlogBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MyLittleBlog";
}
