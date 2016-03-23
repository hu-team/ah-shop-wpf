using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ah_shop_wpf
{
    public class Product
    {
        public int id;
        public string name;
        public string info;
        public double price;

        public override string ToString()
        {
            String value = String.Format("{0}, €{1}", name, price);
            return value;
        }
    }

    public class getProducts
    {
        public string type;
        public List<Product> data;
    }
}
