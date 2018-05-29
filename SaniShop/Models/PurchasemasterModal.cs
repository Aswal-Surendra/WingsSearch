using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaniShop.DAL;
using System.Web.Mvc;


namespace SaniShop.Models
{
    public class PurchasemasterModal
    {
        public int id { get; set; }
        public string purchase_id { get; set; }
        public string   product_name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string PurchaseDate { get; set; }
        public decimal price { get; set; }
        public string additionalComment { get; set; }
        public string SupplierName { get; set; }
        

        public string Product_id { get; set; }
        public List<SelectListItem> Productname { get; set; }
        public string supplier_id { get; set; }
        public  List<SelectListItem> supplier_Name { get; set; }

        // public string Product_name { get; set; }
        // public string TotalAmount { get; set; }


    }
}