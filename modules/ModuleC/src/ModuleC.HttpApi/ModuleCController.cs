using ModuleC.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ModuleC;

public abstract class ModuleCController : AbpControllerBase
{
    protected ModuleCController()
    {
        LocalizationResource = typeof(ModuleCResource);
    }
}
