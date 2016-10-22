using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
//using System.ServiceModel;

namespace StoreDataContracts
{
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "StoreDataContracts.ContractType".
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "StoreService.ContractType".
    [DataContract]
    public class Product
    {
        #region Fields

        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string MakerName { get; set; }
        [DataMember]
        public string QuantityPerUnit { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public bool Discontinued { get; set; }

        #endregion // Fields

        #region Overrides
        //[OperationContract]
        public override string ToString()
        {
            return String.Format(
                "ProductName: " + this.ProductName + "\n" +
                "ProductID: " + this.ProductID + "\n" +
                "MakerName: " + this.MakerName + "\n" +
                "QuantityPerUnit: " + this.QuantityPerUnit + "\n" +
                "UnitPrice: " + this.UnitPrice + "\n" +
                "Discontinued: " + this.Discontinued + "\n");
        }

        #endregion // Overrides
    }
}
