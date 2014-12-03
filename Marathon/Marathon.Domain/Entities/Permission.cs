using System;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class Permission : Entity<Guid>
    {
        public virtual string Description { get; set; }
    }
}
