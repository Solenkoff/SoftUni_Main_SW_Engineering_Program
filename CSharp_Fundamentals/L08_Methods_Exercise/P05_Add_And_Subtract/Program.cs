using System;

namespace _05_Add_And_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstInteger = int.Parse(Console.ReadLine());
            int secondInteger = int.Parse(Console.ReadLine());
            int thirdInteger = int.Parse(Console.ReadLine());

            SumOfFirstTwoIntegers(firstInteger, secondInteger);

            Console.WriteLine(SubtractThirdFromSum(SumOfFirstTwoIntegers(firstInteger, secondInteger), thirdInteger));

        }


        private static int SubtractThirdFromSum(int SumOfFirstTwoIntegers, int thirdInteger)
        {
            int subtraction = SumOfFirstTwoIntegers - thirdInteger;
            return subtraction;
        }

        private static int SumOfFirstTwoIntegers(int firstInteger, int secondInteger)
        {
            int sum = firstInteger + secondInteger;
            return sum;
        }

    }
}
