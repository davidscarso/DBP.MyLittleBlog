using DBP.MyLittleBlog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DBP.MyLittleBlog.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MyLittleBlogController : AbpControllerBase
{
    protected MyLittleBlogController()
    {
        LocalizationResource = typeof(MyLittleBlogResource);
    }
}
