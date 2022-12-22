using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModuleB
{
    public interface IEntityBAppService : IApplicationService
    {
        public Task<CalculatedResultDto> GetCalculatedResultAsync(Guid id);
    }
}




