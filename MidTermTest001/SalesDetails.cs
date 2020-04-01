using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1SalesMS.Model
{
    public class SalesDetails
    {
        public string TransactionID { get; set; }
        public string ProductID { get; set; }
        public string EmployeeID { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
