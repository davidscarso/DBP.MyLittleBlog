using ModuleC.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ModuleC.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ModuleCPageModel : AbpPageModel
{
    protected ModuleCPageModel()
    {
        LocalizationResourceType = typeof(ModuleCResource);
        ObjectMapperContext = typeof(ModuleCWebModule);
    }
}
