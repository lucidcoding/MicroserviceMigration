using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Marathon.Data.Common;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.External.UI.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        [Inject]
        public IContextProvider ContextProvider { get; set; }

        [Inject]
        public IUserRepository UserRepository { get; set; }

        private readonly string _permission;

        public CustomAuthorizeAttribute(string permission)
        {
            _permission = permission;
        }

        //TODO:
        //Some way of only opening one context? Close it whether action is called or not? - entityframeworkReadAttribute is not call 
        //if this authorization fails.
        //
        //Could use caching for performance
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            using (ContextProvider)
            {
                var username = httpContext.User.Identity.Name;
                var user = UserRepository.GetByUsername(username);

                if (user.Role.PermissionRoles.Any(x => x.Permission.Description.Equals(_permission)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}