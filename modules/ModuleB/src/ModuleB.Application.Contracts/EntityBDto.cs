using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ModuleB
{
    public class EntityBDto : EntityDto<Guid>
    {
        public int Value { get; set; }

    }
}
