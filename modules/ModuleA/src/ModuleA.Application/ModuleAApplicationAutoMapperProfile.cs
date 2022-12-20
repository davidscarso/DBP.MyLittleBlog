using AutoMapper;

namespace ModuleA;

public class ModuleAApplicationAutoMapperProfile : Profile
{
    public ModuleAApplicationAutoMapperProfile()
    {
        CreateMap<TodoOne, TodoOneDto>();
        CreateMap<TodoOneDto, TodoOne>();
    }
}
