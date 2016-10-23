using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreBDO;
using StoreDAL;

namespace StoreLogic
{
    public class ProductLogic
    {

        ProductDAO _productDAO = new ProductDAO();

        public ProductBDO GetProduct(int id)
        {
            return _productDAO.GetProduct(id);
        }

        public bool UpdateProduct(ProductBDO product, ref string message)
        {
            var productInDB = GetProduct(product.ProductID);

            // invalid product to update
            if (productInDB == null)
            {
                message = "cannot get product for this ID";
                return false;
            }

            // a product can't be discontinued if they're non-fulfilled orders
            if (product.Discontinued && productInDB.UnitsOnOrder > 0)
            {
                message = "cannot discontinue this product";
                return false;
            }
            else
            {
                return _productDAO.UpdateProduct(product, ref message);
            }
        }

    }
}