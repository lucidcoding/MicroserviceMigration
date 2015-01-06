using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marathon.Domain.Constants
{
    public static class RoleIds
    {
        public static readonly Guid Guest = new Guid("80fc2a10-d07e-4e06-9b91-4ba936e335ba");
        public static readonly Guid Admin = new Guid("8dc59a62-a077-41cc-bac7-f8be505ae4a8");
        public static readonly Guid Customer = new Guid("2C6E33B8-BD7C-492C-807D-B4B1BCAE5F4F");
    }
}
