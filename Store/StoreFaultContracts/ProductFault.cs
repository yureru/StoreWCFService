using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace StoreFaultContracts
{
    [DataContract]
    public class ProductFault
    {

        [DataMember]
        public string FaultMessage;

        public ProductFault(string msg)
        {
            FaultMessage = msg;
        }

    }
}
