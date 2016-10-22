using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using StoreDataContracts;

namespace StoreService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ProductService : IProductService
    {
        public Product GetProduct(int id)
        {
            var product = new Product();

            product.ProductID = 7;
            product.ProductName = "Zanahoria";
            product.UnitPrice = 4.90m;
            product.QuantityPerUnit = "Kg";

            return product;
        }

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
                message = "Product updated successfully";
                result = true;
            }

            return result;
        }

        public string PrintProduct(Product product)
        {
            return product.ToString();
        }
    }
}
