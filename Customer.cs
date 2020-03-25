using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        public List<string> names;
            string name;
        public Customer()
        {
            for(int i = 0; i<30; i++)
            {
                names.Add("Customer" + i);
            }
                
        }

    }
}
