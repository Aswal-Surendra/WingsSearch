using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;
using SaniShop.DAL;
using AutoMapper;

namespace SaniShop.Controllers
{
    [CustomAuthorize("Admin")]
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetPurchaseHome()

        {
            var purchasemasterModal = new PurchasemasterModal();
            var db1 = new SainiShopEntities1();
            var query = db1.SupplierMasters.Select(c => new SelectListItem
            {
                Value = c.SupplierId.ToString(),
                Text = c.SupplierName,

                //Selected = c.Product_id.Equals(3)
            }).ToList();
            var model = new PurchasemasterModal { supplier_Name = query.ToList() };            
            return View(model);
        }

        [HttpPost]
        public JsonResult GetPurchaseHome( string suplid, string Productname, string Quantity, string Desc, decimal Price, string Addcomments)
        {
            PurchaseDetail obj1 = new PurchaseDetail();
            obj1.SupplierName = suplid;
            obj1.product_name = Productname;
            obj1.Description = Desc;
            obj1.Quantity = Quantity;
            obj1.price = Price;
            obj1.additionalComment = Addcomments;
            obj1.Description = Desc;
            obj1.PurchaseDate = DateTime.Now.ToString();
            //obj.watt = Watts;
            //obj.Product_name = Item;
            //obj.Product_price = Price;
            //obj.Quantity = Quantity;
            //obj.Amount = TotalAmo;
            //obj.sales_date = DateTime.Now.ToString();
            //obj.AdditionalComments = Addcomments;
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                objDb.PurchaseDetails.Add(obj1);
                objDb.SaveChanges();
            }
            var response = new Response(true, "Contact Successfully Submitted");
            return Json(response);
            
        }
        //public ActionResult GetPurchaseHome(PurchasemasterModal request)
        //{
        //    PurchaseDetail obj1 = new PurchaseDetail();// {Product_name=request.product_name, };
        //    obj1.SupplierName = request.SupplierName;
        //   // obj1.product_name = request.product_name;
        //    obj1.Quantity = request.Quantity;
        //    obj1.price = request.price;


        //    using (SainiShopEntities1 objDb = new SainiShopEntities1())
        //    {
        //        objDb.PurchaseDetails.Add(obj1);
        //        //objDb.ProductMasters.Add(obj1);
        //        objDb.SaveChanges();
        //    }

        //    return View();

        //}

        public ActionResult fillProductName(int supplierid)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var sup = (from supm in objDb.SupplierMasters
                       join prom in objDb.ProductMasters
                       on supm.SupplierId equals prom.Product_id
                       where supm.SupplierId == supplierid
                        select new
                        {
                            id = supm.SupplierId,
                           sup = prom.Product_name,
                            description = prom.Description,
                            //price = prom.UnitperPrice
                        }).ToList();

            return Json(sup, JsonRequestBehavior.AllowGet);
        }

        //public Dictionary<int, string> ProductList()
        //{

        //    Dictionary<int, string> lista = new Dictionary<int, string>();
        //    using (SainiShopEntities1 objDb = new SainiShopEntities1())
        //    {
        //     var obj = (from k in objDb.ProductMasters select new { k.Product_id, k.Product_name}).ToList();// .ToList();

        //        foreach (var iteam in obj)
        //        {
        //            lista.Add(iteam.Product_id, iteam.Product_name);
        //        }
        //    }
        //    return lista;
        //}

    }
}