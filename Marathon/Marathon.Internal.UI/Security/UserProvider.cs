using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marathon.Internal.UI.Security
{
    public class UserProvider : IUserProvider
    {
        public string GetUsername()
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}