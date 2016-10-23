using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreBDO;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreDAL
{
    public class ProductDAO
    {

        string connectionString = 
        ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

        public ProductBDO GetProduct(int id)
        {
            ProductBDO p = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText =
                        "select * from Products where ProductID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            p = new ProductBDO();
                            p.ProductID = id;
                            p.ProductName = (string)reader["ProductName"];
                            p.QuantityPerUnit = (string)reader["QuantityPerUnit"];
                            p.UnitPrice = (decimal)reader["UnitPrice"];
                            p.UnitsInStock = (short)reader["UnitsInStock"];
                            p.UnitsOnOrder = (short)reader["UnitsOnOrder"];
                            p.ReorderLevel = (short)reader["ReorderLevel"];
                            p.Discontinued = (bool)reader["Discontinued"];

                        }
                    }
                }
            }

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
