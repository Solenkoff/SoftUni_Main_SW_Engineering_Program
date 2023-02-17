using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Painting_s_Order
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> paintings = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string command = commands[0];

                if (command == "Change")
                {
                    int paintingNumber = int.Parse(commands[1]);
                    int newnumber = int.Parse(commands[2]);

                    if (paintings.Contains(paintingNumber))
                    {
                        int index = paintings.IndexOf(paintingNumber);
                        paintings[index] = newnumber;
                    }
                }
                if (command == "Hide")
                {
                    int paintingNumber = int.Parse(commands[1]);
                    if (paintings.Contains(paintingNumber))
                    {
                        paintings.Remove(paintingNumber);
                    }
                }
                if (command == "Switch")
                {
                    int paintingNumberOne = int.Parse(commands[1]);
                    int paintingNumberTwo = int.Parse(commands[2]);

                    if (paintings.Contains(paintingNumberOne) && paintings.Contains(paintingNumberTwo))
                    {
                        int indexOne = paintings.IndexOf(paintingNumberOne);
                        int indexTwo = paintings.IndexOf(paintingNumberTwo);

                        paintings[indexOne] = paintingNumberTwo;
                        paintings[indexTwo] = paintingNumberOne;

                    }

                }
                if (command == "Insert")
                {
                    int index = int.Parse(commands[1]) + 1;
                    int newPainting = int.Parse(commands[2]);

                    if (index >= 0 && index < paintings.Count)
                    {
                        paintings.Insert(index, newPainting);
                    }
                }
                if (command == "Reverse")
                {
                    paintings.Reverse();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', paintings));

        }
    }
}
