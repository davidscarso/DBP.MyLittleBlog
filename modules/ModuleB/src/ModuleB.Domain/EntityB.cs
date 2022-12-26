using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace ModuleB
{
    public class EntityB : Entity<Guid>
    {
        public int Value1 { get; set; } = 0;
        public int Value2 { get; set; } = 0;

        public EntityB() { }

        public EntityB(Guid id, int value1, int value2) : base(id)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public int CalculateValue()
        {
            return Value1 + Value2;
        }

    }
}
