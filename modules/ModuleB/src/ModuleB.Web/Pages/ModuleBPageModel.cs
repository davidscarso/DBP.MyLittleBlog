using ModuleB.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ModuleB.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ModuleBPageModel : AbpPageModel
{
    protected ModuleBPageModel()
    {
        LocalizationResourceType = typeof(ModuleBResource);
        ObjectMapperContext = typeof(ModuleBWebModule);
    }
}
