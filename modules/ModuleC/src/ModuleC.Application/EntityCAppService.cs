using ModuleB;
using System;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace ModuleC
{
    public class EntityCAppService : ModuleCAppService, IEntityCAppService
    {
        private readonly IEntityBAppService _EntityBAppServicer;

        public EntityCAppService(IEntityBAppService entityBAppServicer)
        {
            _EntityBAppServicer = entityBAppServicer;
        }

        public async Task<ResultCDto> GetCalculationAsync(Guid entityBID)
        {
            //recupar id b y obtener el calculos.
            var resultDto = await _EntityBAppServicer.GetCalculationAsync(entityBID);
            return new ResultCDto(resultDto.Result);
        }
    }
}
