using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.DAL;
namespace SaniShop.Models
{
    public class ProductModal
    {
        public int Product_id { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public int unitperprice { get; set; }
        public List<SelectListItem> Productname { get; set; }
    }
}