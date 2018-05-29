using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaniShop.Controllers
{
    public class ReportController : Controller, IModelBinder
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object ob = 5;

            return ob;
        }

    }
}