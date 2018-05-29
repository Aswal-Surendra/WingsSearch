using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaniShop
{
    public class Identity : Controller
    {
        public bool Identitys()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }        
    }
}