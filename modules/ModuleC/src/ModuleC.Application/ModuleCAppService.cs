using ModuleC.Localization;
using Volo.Abp.Application.Services;

namespace ModuleC;

public abstract class ModuleCAppService : ApplicationService
{
    protected ModuleCAppService()
    {
        LocalizationResource = typeof(ModuleCResource);
        ObjectMapperContext = typeof(ModuleCApplicationModule);
    }
}
