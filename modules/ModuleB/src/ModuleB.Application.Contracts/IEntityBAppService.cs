using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModuleB
{
    public interface IEntityBAppService : IApplicationService
    {
        Task<EntityBResultDto> GetCalculationAsync(Guid id);
    }
}
