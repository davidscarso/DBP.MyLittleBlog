using System;
using Volo.Abp.Domain.Entities;

namespace ModuleB
{
    public class EntityB : Entity<Guid>
    {
        public int Value { get; set; } = 0;

        public int Calculate()
        {
            return Value + 1000;
        }
    }
}
