using System;

namespace _05_Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string stringOne = Console.ReadLine();
            string stringTwo = Console.ReadLine();

            int daysDifference = DateModifier.DaysDifference(stringOne, stringTwo);

            Console.WriteLine(daysDifference);

        }

    }
}
