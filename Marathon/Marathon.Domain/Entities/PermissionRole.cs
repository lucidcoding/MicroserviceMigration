using System;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class PermissionRole : Entity<Guid>
    {
        public virtual Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
