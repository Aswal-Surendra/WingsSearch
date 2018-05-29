using SaniShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;
using DataTables.Mvc;

namespace SaniShop.Controllers
{
    //[Authorize]
    [CustomAuthorize("Admin")]
    public class SalesController : Controller
    {
        public SalesController()
        {
            Identity obj = new Identity();
            if (!obj.Identitys())
            {

            }
        }

        // GET: Sales
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            var use = User.Identity.Name.ToString();
            var ause = User.Identity;

            var db1 = new SainiShopEntities1();
            var query = db1.ProductMasters.Select(c => new SelectListItem
            {
                Value = c.Product_id.ToString(),
                Text = c.Product_name,

                //Selected = c.Product_id.Equals(3)
            }).ToList();

            var model = new SalesDetailModel { Productname = query.ToList() };
            return View(model);
        }
        [HttpPost]
        public JsonResult Index(string Quantity, string Item, int Watts, string TotalAmo, string Desc, string Price, string Addcomments)
        {
            Sales_Details obj = new Sales_Details();
            obj.Description = Desc;
            obj.watt = Watts;
            obj.Product_name = Item;
            obj.Product_price = Price;
            obj.Quantity = Quantity;
            obj.Amount = TotalAmo;
            obj.sales_date = DateTime.Now.ToString();
            obj.AdditionalComments = Addcomments;
            using (SainiShopEntities1 objDb = new SainiShopEntities1())
            {
                objDb.Sales_Details.Add(obj);
                objDb.SaveChanges();
            }
            var response = new Response(true, "Contact Successfully Submitted");
            return Json(response);
        }

        public ActionResult FillWatt(int Productid)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var watt = (from prod in objDb.ProductMasters
                        join wat in objDb.WattMasters
                        on prod.Product_id equals wat.product_id
                        where prod.Product_id == Productid
                        select new
                        {
                            id = prod.Product_id,
                            watt = wat.watt,
                            description = prod.Description,
                            price = prod.UnitperPrice
                        }).ToList();

            return Json(watt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TotalAmount(string Unitprice, string Quantity, int Productid)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            var margin = objDb.ProductMasters.Where(z => z.Product_id == Productid).Select(x => x.marginPerUnit).FirstOrDefault();
            var response = TotalPrice(Unitprice, Quantity, margin);
            return Json(response);
        }


        public decimal TotalPrice(string Unitprice, string Quantity, int? margin)
        {
            var amount = Convert.ToInt32(Unitprice) * Convert.ToInt32(Quantity);
            var totalprice = (amount * margin / 100) + amount;
            return Convert.ToDecimal(totalprice);
        }

        public ActionResult salesDataView()
        {
            return View();
        }

        public ActionResult salesDataTable([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            SainiShopEntities1 objDb = new SainiShopEntities1();
            //var records = objDb.Sales_Details;
            IQueryable<Sales_Details> query = objDb.Sales_Details;
            var totalCount = query.Count();

            #region Filtering
            // Apply filters for searching
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim();
                query = query.Where(p => p.Product_name.Contains(value) ||
                                         p.Quantity.Contains(value) ||
                                         p.sales_date.Contains(value) ||
                                         p.Product_price.Contains(value)
                                   );
            }
            var filteredCount = query.Count();
            #endregion Filtering

            #region Sorting
            // Sorting
            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var orderByString = String.Empty;

            foreach (var column in sortedColumns)
            {
                orderByString += orderByString != String.Empty ? "," : "";
                orderByString += (column.Data) + (column.SortDirection == Column.OrderDirection.Ascendant ? " asc" : " desc");
            }

            query = query.OrderBy(x => x.sales_date??"Product_price asc");//orderByString == string.Empty ? "Product_price asc" : orderByString);
           

            #endregion Sorting

            // Paging
            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            var data = query.Select(asset => new
            {
                Id = asset.id,
                ProductName = asset.Product_name,
                ProductPrice = asset.Product_price,
                SalesDate = asset.sales_date,
                Quantity = asset.Quantity
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount), JsonRequestBehavior.AllowGet);

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
