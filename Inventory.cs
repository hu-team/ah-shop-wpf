using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ah_shop_wpf
{
    class Inventory
    {
        public int id;
        public string name;
        public int amount;

        public override string ToString()
        {
            String value = String.Format("{0}, {1}", name, amount);

            return value;
        }
    }

    class getInventory
    {
        public string type;
        public List<Inventory> data;
    }
}
