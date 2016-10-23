using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using StoreDataContracts;
using StoreFaultContracts;

namespace StoreService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    /* Note: I'm thinking of having different WCF services (projects) for each client, for example: in a POS StoreService will serve as a (obvs) service.
     * But for the updater client, that is the application that does CRUD for the Products should be in a service called maybe "StoreServiceAdminProducts", which will have
     * a higher admin priviledges and will allow things like updating the price of the product, create a new product, discontinue. (Pretty much like we're doing here with UpdateProduct function).
     */
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [FaultContract(typeof(ProductFault))]
        Product GetProduct(int id);

        [OperationContract]
        [FaultContract(typeof(ProductFault))]
        bool UpdateProduct(Product product, ref string message);

        [OperationContract]
        string PrintProduct(Product product);

    }
}
