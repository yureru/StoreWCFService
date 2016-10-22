using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreBDO;

namespace StoreLogic
{
    public class ProductLogic
    {

        public ProductBDO GetProduct(int id)
        {
            // Dummy data
            ProductBDO product = new ProductBDO();

            product.ProductName = "Lettuce";
            product.MakerName = "Ranch Natural";
            product.ProductID = 11;
            product.QuantityPerUnit = "1";
            product.UnitPrice = 8.90m;
            product.UnitsInStock = 100;
            product.UnitsInOrder = 5;
            product.ReorderLevel = 20;
            product.Discontinued = false;

            return product;
        }

        public bool UpdateProduct(ProductBDO product, ref string message)
        {
            if (product == null)
            {
                message = "Cannot get this product from the DB";
                return false;
            }

            if (product.Discontinued && product.UnitsInOrder > 0)
            {
                message = "Cannot discontinue this product since they're unfulfilled orders";
                return false;
            }

            // TODO: Update product here
            return true;
        }

    }
}
