using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using FileHelpers;

namespace CSVParseTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\xxx\xxx.csv";
            List<Product> products;

            var rows = new List<string[]>();
            using (var textReader = new StreamReader(path))
            {
                //var csv = new CsvReader(textReader);
                //csv.Configuration.IgnoreQuotes = true;
                var parser = new CsvParser(textReader);
                int count = 0;
                while (true)
                {
                    var row = parser.Read();
                    count++;
                    if (row == null)
                    {
                        // handle the end
                        break;
                    }
                    
                    if(row[6] == null)
                    {
                        // have we got an issue with " escape character
                        // search for index of the comma - need to split either side
                        // if nothing in row[1], search row[2] then row[3] - these are title, cat1 and cat2
                        // s have to be in those fields
                        string sub1 = "";
                        string sub2 = "";
                        int iTrack = 1;
                        for (int i = 1; i < 3; i++)
                        {
                            var test = row[i].Substring(0).IndexOf(',');
                            if (test != -1)
                            {
                                sub1 = row[i].Substring(0, test);
                                sub2 = row[i].Substring(test + 1, (row[1].Length - (test + 2)));
                                break;
                            }
                            iTrack++;
                        }

                        // now need to handle where the mystery field was located
                        if (iTrack == 1)
                        {
                            string[] xRow = { row[0], sub1, sub2, row[2], row[3], row[4], row[5] };
                            rows.Add(xRow);
                        }
                        else if (iTrack == 2)
                        {
                            string[] xRow = { row[0], row[1], sub1, sub2, row[3], row[4], row[5] };
                            rows.Add(xRow);
                        }
                        else if (iTrack == 3)
                        {
                            string[] xRow = { row[0], row[1], row[2], sub1, sub2, row[4], row[5] };
                            rows.Add(xRow);
                        }

                    }
                    else
                    {
                        // if have a nice looking product (no null in element 7), then just add the prsed row
                        // unless it is the first one - then it breaks our product field types
                        if(count == 1)
                        {
                            continue;
                        }
                        else
                        {
                            rows.Add(row);
                        }
                        
                    }
                    
                }
                //using (csv)
                //{
                //    products = csv.GetRecords<Product>().ToList();
                //}
                
            }

            // now need to take nicely parsed csv and then convert to products, so can feed into existing code
            // want this outside using statement for streamreder to remove any dependance
            List<Product2> product2s = new List<Product2>();
            foreach (var row in rows)
            {
                Product2 prod = new Product2
                {
                    barcode = row[0],
                    title = row[1],
                    category1 = row[2],
                    category2 = row[3],
                    price = Convert.ToDecimal(row[4]),
                    sale_price = Convert.ToDecimal(row[5]),
                    count_on_hand = Convert.ToInt32(row[6])
                };

                product2s.Add(prod);
            }

            Console.WriteLine("ben");

            using (var writer = new StreamWriter(@"C:\xxx\test.csv"))
            using (var wcsv = new CsvWriter(writer))
            {
                wcsv.WriteRecords(product2s);
            }
            
                foreach (var prod in product2s)
                {
                Console.WriteLine("Github test. This if for the Branch_2_Test");
                }
        }
    }
}
