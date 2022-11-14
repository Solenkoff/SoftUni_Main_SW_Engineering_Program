using System;
using System.Text.RegularExpressions;

namespace _03_SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"%(?<name>[A-Z][a-z]+)%[^\.\|\$\%]*<(?<product>\w+)>[^\.\|\$\%]*\|(?<count>\d+)\|[^\.\|\$\%]*?(?<price>\d+\.?\d*)\$";

            Regex regex = new Regex(pattern);

            double total = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double orderTotal = price * quantity;

                    total += orderTotal;

                    Console.WriteLine($"{name}: {product} - {orderTotal:f2}");
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {total:f2}");

        }
    }
}
