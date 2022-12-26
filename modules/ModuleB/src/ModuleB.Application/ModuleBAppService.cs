using ModuleB.Localization;
using Volo.Abp.Application.Services;

namespace ModuleB;

public abstract class ModuleBAppService : ApplicationService
{
    protected ModuleBAppService()
    {
        LocalizationResource = typeof(ModuleBResource);
        ObjectMapperContext = typeof(ModuleBApplicationModule);
    }
}
