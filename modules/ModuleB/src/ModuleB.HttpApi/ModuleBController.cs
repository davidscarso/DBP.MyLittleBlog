using ModuleB.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ModuleB;

public abstract class ModuleBController : AbpControllerBase
{
    protected ModuleBController()
    {
        LocalizationResource = typeof(ModuleBResource);
    }
}
