using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using StoreDataContracts;
using StoreLogic;
using StoreBDO;

namespace StoreService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ProductService : IProductService
    {

        #region Members

        //ProductBDO _product;
        ProductLogic _productLogic = new ProductLogic();

        #endregion // Members

        public Product GetProduct(int id)
        {
            var productBDO = _productLogic.GetProduct(id);

            if (productBDO == null)
            {
                throw new Exception("No product found for id " + id);
            }

            var product = new Product();
            TranslateProductBDOToProductDTO(productBDO, product);

            return product;
        }

        #region Interface Implementations

        public bool UpdateProduct(Product product, ref string message)
        {
            var result = true;

            // Check if valid price
            if (product.UnitPrice <= 0)
            {
                message = "Price cannot be <= 0";
                result = false;
            }
            else if (string.IsNullOrEmpty(product.ProductName))
            {
                message = "Product name cannot be empty";
                result = false;
            }
            else if (string.IsNullOrEmpty(product.QuantityPerUnit))
            {
                message = "Quantity cannot be empty";
                result = false;
            }
            else
            {
                var productBDO = new ProductBDO();
                TranslateProductDTOToProductBDO(product, productBDO);
                return _productLogic.UpdateProduct(productBDO, ref message);
            }

            return result;
        }

        public string PrintProduct(Product product)
        {
            return product.ToString();
        }

        #endregion // Interface Implementations

        #region Private Helpers

        void TranslateProductBDOToProductDTO(ProductBDO productBDO, Product product)
        {
            product.ProductName = productBDO.ProductName;
            product.ProductID = productBDO.ProductID;
            product.MakerName = productBDO.MakerName;
            product.QuantityPerUnit = productBDO.QuantityPerUnit;
            product.UnitPrice = productBDO.UnitPrice;
            product.Discontinued = productBDO.Discontinued;
        }

        void TranslateProductDTOToProductBDO(Product product, ProductBDO productBDO)
        {
            productBDO.ProductName = product.ProductName;
            productBDO.ProductID = product.ProductID;
            productBDO.MakerName = product.MakerName;
            productBDO.QuantityPerUnit = product.QuantityPerUnit;
            productBDO.UnitPrice = product.UnitPrice;
            productBDO.Discontinued = product.Discontinued;
        }

        #endregion // Private Helpers
    }
}
