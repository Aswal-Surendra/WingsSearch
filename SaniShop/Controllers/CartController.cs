using Newtonsoft.Json;
using SaniShop.DAL;
using SaniShop.Models;
using SaniShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaniShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            using (SainiShopEntities1 obj = new SainiShopEntities1())
            {
                var model = obj.Product_Master?.ToList();
                return View(model);
            }               
        }

        [HttpGet]
        public ActionResult GetCart(int id)
        {
            try
            {
                    var cartRepository = new CartRepository();                
                    var model = cartRepository.GetProduct(id);
                    return View(model);                
            }
            catch(Exception ex) {
                return null;
            }
        }

        public JsonResult AddToCart(string selected)
        {             
            int[] nums = selected.Split(',').Select(int.Parse).ToArray();
            ViewBag.Count = nums.Length;
            return Json(ViewBag.Count, JsonRequestBehavior.AllowGet);
        }

    }
}