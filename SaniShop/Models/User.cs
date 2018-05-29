using SaniShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaniShop.Models;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace SaniShop.Models
{
    public class Users : Controller
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public bool IsValid(string _username, string _password)
        {        
            var encodepassword = Encode(_password);
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                User users = (from u in objDb.Users
                             where u.Username.Equals(_username) && u.Password.Equals(encodepassword)
                             select u).FirstOrDefault();
                if (users != null) { return true; } else { return false; }
            }          
        }

        public string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };

        }

    }
}