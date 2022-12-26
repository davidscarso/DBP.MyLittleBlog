using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ModuleB
{
    public class EntityBDto : EntityDto
    {
        public int Value1 { get; set; } = 0;
        public int Value2 { get; set; } = 0;
    }
}
