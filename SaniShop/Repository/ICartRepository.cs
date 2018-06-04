using SaniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaniShop.Repository
{
   public interface ICartRepository
    {
        IQueryable<Product_Summary> GetProduct(int id);
    }
}
