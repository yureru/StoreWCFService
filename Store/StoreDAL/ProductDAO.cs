using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreBDO;

namespace StoreDAL
{
    public class ProductDAO
    {

        public ProductBDO GetProduct(int id)
        {
            // TODO: Connect to the DB
            var p = new ProductBDO();
            p.ProductID = id;
            p.ProductName = "product from DAL";
            p.UnitPrice = 10.00m;
            p.QuantityPerUnit = "Kg.";

            return p;
        }

        public bool UpdateProduct(ProductBDO product, ref string message)
        {
            // TODO: Connect to the DB
            message = "product updated successfully";
            return true;
        }

    }
}
