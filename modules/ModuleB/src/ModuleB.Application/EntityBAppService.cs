using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ModuleB
{
    public class EntityBAppService : ModuleBAppService
    {
        private readonly IRepository<EntityB, Guid> _entityBRepository;

        public EntityBAppService(IRepository<EntityB, Guid> entityBRepository)
        {
            _entityBRepository = entityBRepository;
        }

        public async Task<List<EntityBDto>> GetAll()
        {
            return ObjectMapper.Map<List<EntityB>, List<EntityBDto>>(await _entityBRepository.GetListAsync());
        }

        public async Task<EntityBDto> CreateAsync(EntityBDto todoOneDto)
        {
            var EntityB = ObjectMapper.Map<EntityBDto, EntityB>(todoOneDto);
            var createdEntityB = await _entityBRepository.InsertAsync(EntityB);
            return ObjectMapper.Map<EntityB, EntityBDto>(createdEntityB);
        }

        public async Task<EntityBDto> UpdateAsync(EntityBDto todoOneDto)
        {
            var EntityB = ObjectMapper.Map<EntityBDto, EntityB>(todoOneDto);
            var createdEntityB = await _entityBRepository.UpdateAsync(EntityB);
            return ObjectMapper.Map<EntityB, EntityBDto>(createdEntityB);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var EntityB = await _entityBRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (EntityB != null)
            {
                await _entityBRepository.DeleteAsync(EntityB);
                return true;
            }
            return false;
        }
    }
}