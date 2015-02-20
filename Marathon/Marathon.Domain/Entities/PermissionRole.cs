using System;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class PermissionRole : Entity<Guid>
    {
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
