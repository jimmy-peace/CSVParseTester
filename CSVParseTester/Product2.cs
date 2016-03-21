using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParseTester
{
    public class Product2
    {
        public Product2()
        {

        }

        public string barcode { get; set; }

        public string title { get; set; }

        public string category1 { get; set; }

        public string category2 { get; set; }

        public Decimal price { get; set; }

        public Decimal sale_price { get; set; }

        public int count_on_hand { get; set; }
    }
}
