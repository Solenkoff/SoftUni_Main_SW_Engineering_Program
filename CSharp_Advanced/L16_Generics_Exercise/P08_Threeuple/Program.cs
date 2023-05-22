using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstTupleData = Console.ReadLine()
                                              .Split(" ");
            string fullName = $"{firstTupleData[0]} {firstTupleData[1]}";
            string address = firstTupleData[2];

           //string[] townData = new string[firstTupleData.Length - 3];
           //for (int i = 0; i < townData.Length; i++)
           //{
           //    townData[i] = firstTupleData[i + 3];
           //}
           //string town = string.Join(" ", townData);

            List<string> townRowData = firstTupleData.ToList().Skip(3).ToList();
            string town = string.Join(" ", townRowData);
            Threeuple<string, string, string> firstThreeuple =
                     new Threeuple<string, string, string>(fullName, address, town);


            string[] secondTupleData = Console.ReadLine()
                                              .Split(" ");
            string name = secondTupleData[0];
            int amountOfBeer = int.Parse(secondTupleData[1]);
            string drunkOrNot = secondTupleData[2];
            bool isDrunk = drunkOrNot == "drunk";
            

            Threeuple<string, int, bool> secondThreeuple =
                     new Threeuple<string, int, bool>(name, amountOfBeer, isDrunk);


            string[] thirdTupleData = Console.ReadLine()
                                             .Split(" ");
            string firstName = thirdTupleData[0];
            double accountBalance = double.Parse(thirdTupleData[1]);
            string bankName = thirdTupleData[2];

            Threeuple<string, double, string> thirdThreeuple =
                     new Threeuple<string, double, string>(firstName, accountBalance, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
