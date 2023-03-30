using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07_SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> reservations = new HashSet<string>();
            HashSet<string> reservationsVip = new HashSet<string>();

            string pattern = @"\d\S{7}";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                Match match = regex.Match(input);
                if(match.Success)
                {
                    reservationsVip.Add(input);
                }
                else
                {
                    reservations.Add(input);
                }
               
                input = Console.ReadLine();
            }

            string guest = Console.ReadLine();

            while (guest != "END")
            {
                Match match = regex.Match(guest);
                if (match.Success)
                {
                    reservationsVip.Remove(guest);
                }
                else
                {
                    reservations.Remove(guest);
                }

                

                guest = Console.ReadLine();
            }

            int count = reservations.Count + reservationsVip.Count;

            Console.WriteLine(count);

            foreach (var item in reservationsVip)
            {
                Console.WriteLine(item);
            }

            foreach (var exempts in reservations)
            {
                Console.WriteLine(exempts);
            }

        }
    }
}
