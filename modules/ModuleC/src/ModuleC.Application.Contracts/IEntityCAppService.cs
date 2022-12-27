using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModuleC
{
    public interface IEntityCAppService : IApplicationService
    {
        Task<ResultCDto> GetCalculationAsync(Guid entityBID);
    }
}
