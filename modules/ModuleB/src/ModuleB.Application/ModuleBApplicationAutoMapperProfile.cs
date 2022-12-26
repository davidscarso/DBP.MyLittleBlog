using AutoMapper;

namespace ModuleB;

public class ModuleBApplicationAutoMapperProfile : Profile
{
    public ModuleBApplicationAutoMapperProfile()
    {
        CreateMap<EntityBDto, EntityBDto>();
        CreateMap<EntityBDto, EntityBDto>();
    }
}
