using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                                      .Split(' ', StringSplitOptions
                                      .RemoveEmptyEntries).Select(int.Parse)
                                      .ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] comand = input.Split();

                if (comand[0] == "Add")
                {
                    numbers.Add(int.Parse(comand[1]));
                }
                else if (comand[0] == "Insert")
                {
                    int number = int.Parse(comand[1]);
                    int index = int.Parse(comand[2]);

                    if (IsNotValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (comand[0] == "Remove")
                {
                    int index = int.Parse(comand[1]);

                    if (IsNotValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (comand[0] == "Shift")
                {
                    int shiftBy = int.Parse(comand[2]);

                    if (comand[1] == "left")
                    {
                        for (int i = 0; i < shiftBy; i++)
                        {
                            int firstElement = numbers[0];
                            for (int j = 0; j < numbers.Count - 1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }

                            numbers[numbers.Count - 1] = firstElement;
                        }

                    }
                    else if (comand[1] == "right")
                    {
                        for (int i = 0; i < shiftBy; i++)
                        {
                            int lastElement = numbers[numbers.Count - 1];
                            for (int j = numbers.Count - 1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }

                            numbers[0] = lastElement;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(' ', numbers));

        }

        private static bool IsNotValidIndex(int index, int count)
        {
            return index > count || index < 0;
        }

    }
}
