using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06_Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

           
            HashSet<string> cars = new HashSet<string>();

            while (input != "END")
            {
                
                var data = Regex.Split(input, ", ");

                string direction = data[0];
                string carNumber = data[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if (cars.Any())
            {
                foreach (var carNumber in cars)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
