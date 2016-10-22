using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreClient.ProductServiceRef;

namespace StoreClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new ProductServiceClient();

            Console.WriteLine("Testing GetProduct");
            Console.WriteLine(client.PrintProduct(client.GetProduct(7)));

            var test = "test";
            Console.WriteLine("\nTesting UpdateProduct");
            Console.WriteLine(client.UpdateProduct(new Product(), ref test));

            Console.Write("Press any key to close the console...");
            Console.ReadKey();
        }
    }
}
