namespace P06_List_Manipulation_Basics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] token = input.Split();
                switch (token[0])
                {
                    case "Add":
                        int numberAdd = int.Parse(token[1]);
                        numbers.Add(numberAdd);
                        break;
                    case "Remove":
                        int numberRemove = int.Parse(token[1]);
                        numbers.Remove(numberRemove);
                        break;
                    case "RemoveAt":
                        int numberRemoveAt = int.Parse(token[1]);
                        numbers.RemoveAt(numberRemoveAt);
                        break;
                    case "Insert":
                        int numbersInsert = int.Parse(token[1]);
                        int indxInsert = int.Parse(token[2]);
                        numbers.Insert(indxInsert, numbersInsert);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
