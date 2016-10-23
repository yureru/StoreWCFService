using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBDO
{
    public class ProductBDO
    {

        #region Fields

        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public string MakerName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }


        #endregion // Fields

    }
}
