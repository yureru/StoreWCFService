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
            message = "product updated successfully";
            var ret = true;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var cmdStr =
                    @"UPDATE products
                      SET ProductName=@name,
                      QuantityPerUnit=@unit,
                      UnitPrice=@price,
                      Discontinued=@discontinued
                      WHERE ProductID=@id";

                using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
                {
                    cmd.Parameters.AddWithValue("@name", product.ProductName);
                    cmd.Parameters.AddWithValue("@unit", product.QuantityPerUnit);
                    cmd.Parameters.AddWithValue("@price", product.UnitPrice);
                    // MakerName doesn't exists in the DB
                    //cmd.Parameters.AddWithValue("@maker", product.MakerName);
                    cmd.Parameters.AddWithValue("@discontinued", product.Discontinued);
                    cmd.Parameters.AddWithValue("@id", product.ProductID);

                    conn.Open();
                    // here we're checking if the query executed was different to zero it "means" that th eproduct wasn't found
                    // but actually it could update two or more products, so it's better to compare to zero if we want to know
                    // if there wasn't an update, or it caused two or more updates in the query, which means some products
                    // have the same, repeated, id.
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        message = "no product was updated";
                        ret = false;
                    }
                }
            }

            return ret;
        }

    }
}
