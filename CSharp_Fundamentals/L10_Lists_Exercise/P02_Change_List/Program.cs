using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Change_List
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] comand = input.Split();
                if (comand[0] == "delete")
                {
                    for (int i = 0; i < numbers.Count; i++)       //
                    {                                             //
                        if (numbers[i] == int.Parse(comand[1]))   //numbers.RemoveAll(x=>x == int.Parse(comand[1]));
                        {                                         //
                            numbers.Remove(numbers[i]);           //
                        }                                         //
                    }                                             //
                }
                else if (comand[0] == "insert")
                {
                    numbers.Insert(int.Parse(comand[2]), int.Parse(comand[1]));
                }
            }

            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}
