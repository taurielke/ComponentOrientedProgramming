using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1COP.Model
{
    public class Order
    {
        public String BuyerName { set; get; }
        public String ProductName { set; get; }
        public int Price { set; get; }
        override
        public String ToString()
        {
            String obj = BuyerName + " " + ProductName + " " + Price;
            return obj;
        }
    }
}
