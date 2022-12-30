using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {

            int nBarcodes = int.Parse(Console.ReadLine());

            string pattern = @"^@#+[A-Z][a-zA-Z0-9]{4,}[A-Z]@#+$";

            Regex regex = new Regex(pattern);

            string patternNums = @"\d";

            Regex regexNums = new Regex(patternNums);


            for (int i = 0; i < nBarcodes; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string productGroup = "";

                    for (int j = 0; j < match.Value.Length; j++)
                    {

                        if (char.IsDigit(match.Value[j]))
                        {
                            productGroup += match.Value[j];
                        }

                    }

                    if (productGroup != "")
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
