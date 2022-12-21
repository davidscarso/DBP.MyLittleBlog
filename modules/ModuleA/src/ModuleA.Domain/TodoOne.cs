using System;
using Volo.Abp.Domain.Entities;

namespace ModuleA
{
    public class TodoOne : Entity<Guid>
    {
        public string Content { get; set; }
        public bool IsDone { get; set; }
    }
}
