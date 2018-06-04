using SaniShop.DAL;
using SaniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaniShop.Repository
{
    public class CartRepository : ICartRepository
    {
        public IQueryable<Product_Summary> GetProduct(int id)
        {
            SainiShopEntities1 obj = new SainiShopEntities1();            
                var model = obj.Product_Master.Where(x => x.P_id == id).Join(obj.Cart_Details,
                                c => c.P_id,
                                o => o.Product_Categoris,
                                (c, o) => new Product_Summary
                                {
                                    Produc_id = o.P_id,// .P_id,
                                    Product_Name = c.Product_Name,
                                    Sub_Product_Name = o.Sub_Product_Name,
                                    Product_Price = o.Sub_Product_Price
                                });
            return model;
        }
    }
}