using System;
using System.Collections.Generic;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class Role : Entity<Guid>
    {
        public virtual string Description { get; set; }
        public virtual string RoleName { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
