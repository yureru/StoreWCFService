using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreClient.ProductServiceRef;
using System.ServiceModel;

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
            Console.WriteLine("UpdateProduct message was: " + test);

            Console.Write("Press any key to close the console...");

            // FaultException
            //TestException(client, 0);
            // regular C# exception
            //TestException(client, 999);
            Console.ReadKey();
        }

        // Probably you wan't to disable the exceptions Exception, and System.ServiceModel.FaultException'1
        // to be able to catch it here.
        static void TestException(ProductServiceClient client, int id)
        {
            if (id != 999)
            {
                Console.WriteLine("\n\nTest Fault Exception");
            }
            else
            {
                Console.WriteLine("\n\nTest normal Exception");
            }

            try
            {
                var product = client.GetProduct(id);
            }
            catch (TimeoutException err)
            {
                Console.WriteLine("Timeout exception");
            }
            catch (FaultException<ProductFault> err)
            {
                Console.WriteLine("ProductFault.");
                Console.WriteLine("\tFault reason: " + err.Reason);
                Console.WriteLine("\tFault message: " + err.Detail.FaultMessage);
            }
            catch (FaultException err)
            {
                Console.WriteLine("Unknown Fault.");
                Console.WriteLine(err.Message);
            }
            catch (CommunicationException err)
            {
                Console.WriteLine("Communication exception");
            }
            catch (Exception err)
            {
                Console.WriteLine("Unknown exception");
            }
        }
    }
}
