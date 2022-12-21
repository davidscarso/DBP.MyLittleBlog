﻿using AutoMapper;
using ModuleB.EntityBs;

namespace ModuleB;

public class ModuleBApplicationAutoMapperProfile : Profile
{
    public ModuleBApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<EntityB, EntityBDto>();
        CreateMap<EntityBDto, EntityB>();
    }
}
