using DBP.MyLittleBlog.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DBP.MyLittleBlog.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MyLittleBlogPageModel : AbpPageModel
{
    protected MyLittleBlogPageModel()
    {
        LocalizationResourceType = typeof(MyLittleBlogResource);
    }
}
