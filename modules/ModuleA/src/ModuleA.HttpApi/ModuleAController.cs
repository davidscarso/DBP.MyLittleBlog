using ModuleA.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ModuleA;

public abstract class ModuleAController : AbpControllerBase
{
    protected ModuleAController()
    {
        LocalizationResource = typeof(ModuleAResource);
    }
}
