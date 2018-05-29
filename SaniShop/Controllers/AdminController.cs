using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;
using SaniShop.DAL;
using System.Web.Security;

namespace SaniShop.Controllers
{
    public class AdminController : Controller
    {


        [HttpGet]
        public ActionResult AdminHome()
        {

            return View();

        }



        [HttpPost]
        public ActionResult AdminHome(string id)
        {


            return View();

        }
    }
        
}