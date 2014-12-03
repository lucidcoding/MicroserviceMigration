using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class Depot : Entity<Guid>
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string Address4 { get; set; }
        public virtual string PostCode { get; set; }
    }
}
