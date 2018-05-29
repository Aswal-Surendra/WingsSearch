using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaniShop.DAL;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;


namespace SaniShop
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
       
        SainiShopEntities1 db = new SainiShopEntities1();      
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            
            string k = HttpContext.Current.Session["key"]?.ToString();
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                var user = db.Users.Where(m => m.Username == k/* getting user form current context */ && m.Role == role); // checking active users with allowed roles.  
                if (user.Count() > 0)
                {
                    authorize = true; /* return true if Entity has current user(active) with specific role */
                }
            }
            return authorize;
            //GetUser.CurrentUser
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

    }
}