using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace CSVParseTester
{
    public class Product
    {
        private readonly string ben = Convert.ToString('"');

        private string _barcode;
        public string barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value.Trim(new Char[] { ' ', '"' });
            }
        }

        private string _desc;
        public string desc
        {
            get { return _desc; }
            set
            {
                if (value.EndsWith(ben + ben))
                {
                    _desc = value.Trim(new Char[] { ' ', '"' }) + ben;

                }
                else
                {
                    _desc = value.Trim(new Char[] { ' ', '"' });
                }
            }
        }

        private string _cat1;
        public string cat1
        {
            get { return _cat1; }
            set { _cat1 = value.Trim(new Char[] { ' ', '"' }); }
        }

        private string _cat2;
        public string cat2
        {
            get { return _cat2; }
            set { _cat2 = value.Trim(new Char[] { ' ', '"' }); }
        }

        private string _sell;
        public string sell
        {
            get { return _sell; }
            set { _sell = value.Trim(new Char[] { ' ', '"' }); }
        }

        private string _sale;
        public string sale
        {
            get { return _sale; }
            set { _sale = value.Trim(new Char[] { ' ', '"' }); }
        }

        private string _quantity;
        public string quantity
        {
            get { return _quantity; }
            set { _quantity = value.Trim(new Char[] { ' ', '"' }); }
        }

    }
}
