using System;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class PermissionRole : Entity<Guid>
    {
        public virtual Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
