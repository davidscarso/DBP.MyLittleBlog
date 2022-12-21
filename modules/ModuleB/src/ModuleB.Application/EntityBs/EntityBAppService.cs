using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ModuleB.EntityBs
{
    public class EntityBAppService : ModuleBAppService, IEntityBAppService
    {

        private readonly IRepository<EntityB, Guid> entityBRepository;

        public EntityBAppService(IRepository<EntityB, Guid> entityBRepository)
        {
            this.entityBRepository = entityBRepository;
        }

        public async Task<List<EntityBDto>> GetAll()
        {
            return ObjectMapper.Map<List<EntityB>, List<EntityBDto>>(await entityBRepository.GetListAsync());
        }

        public async Task<EntityBDto> CreateAsync(EntityBDto entityBDto)
        {
            var EntityB = ObjectMapper.Map<EntityBDto, EntityB>(entityBDto);
            var createdEntityB = await entityBRepository.InsertAsync(EntityB);
            return ObjectMapper.Map<EntityB, EntityBDto>(createdEntityB);
        }

        public async Task<EntityBDto> UpdateAsync(EntityBDto entityBDto)
        {
            var EntityB = ObjectMapper.Map<EntityBDto, EntityB>(entityBDto);
            var createdEntityB = await entityBRepository.UpdateAsync(EntityB);
            return ObjectMapper.Map<EntityB, EntityBDto>(createdEntityB);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var EntityB = await entityBRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (EntityB != null)
            {
                await entityBRepository.DeleteAsync(EntityB);
                return true;
            }
            return false;
        }

        public async Task<CalculatedResultDto> GetCalculatedResultAsync(Guid id)
        {
            var EntityB = await entityBRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (EntityB != null)
            {
                var res = EntityB.Calculate();
                return new CalculatedResultDto() { CalculatedResult = res };
            }
            return null;
        }
    }
}