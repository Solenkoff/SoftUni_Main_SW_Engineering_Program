using System;

namespace _07_Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] firstTupleData = Console.ReadLine()
                                             .Split(" ");
            string fullName = $"{firstTupleData[0]} {firstTupleData[1]}";
            string address = firstTupleData[2];

            MyTuple<string, string> firstTuple =
                     new MyTuple<string, string>(fullName, address);


            string[] secondTupleData = Console.ReadLine()
                                              .Split(" ");
            string name = secondTupleData[0];
            int amountOfBeer = int.Parse(secondTupleData[1]);

            MyTuple<string, int> secondTuple =
                     new MyTuple<string, int>(name, amountOfBeer);


            string[] thirdTupleData = Console.ReadLine()
                                             .Split(" ");
            int integerNum = int.Parse(thirdTupleData[0]);
            double doubleNum = double.Parse(thirdTupleData[1]);

            MyTuple<int, double> thirdTuple =
                     new MyTuple<int, double>(integerNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
