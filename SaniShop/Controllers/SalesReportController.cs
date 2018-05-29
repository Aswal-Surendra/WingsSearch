using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;
using SaniShop.DAL;

namespace SaniShop.Controllers
{
    public class SalesReportController : Controller
    {
        // GET: SalesReport
        public ActionResult Index()
        {
            var db1 = new SainiShopEntities1();
            var query = db1.ProductMasters.Select(c => new SelectListItem
            {
                Value = c.Product_id.ToString(),
                Text = c.Product_name,

                //Selected = c.Product_id.Equals(3)
            }).ToList();

            var query1 = db1.WattMasters.Select(c => new SelectListItem
            {
                Value = c.product_id.ToString(),
                Text = c.watt.ToString(),

             }).ToList();


            var model = new SalesDetailModel { Productname = query.ToList(), wattmain=query1.ToList() };
            return View(model);
            //return View();
        }
    }
}