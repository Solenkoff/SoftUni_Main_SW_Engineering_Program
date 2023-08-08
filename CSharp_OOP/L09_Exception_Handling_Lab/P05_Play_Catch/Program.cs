namespace P05_Play_Catch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                string[] commandInput = Console.ReadLine().Split();
                string command = commandInput[0];
                
                try
                {
                    int index = int.Parse(commandInput[1]);

                    if (command == "Replace")
                    {
                        int replacement = int.Parse(commandInput[2]);
                        integers[index] = replacement;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = index;
                        int endIndex = int.Parse(commandInput[2]);

                        List<int> intsToPrint = new List<int>();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            intsToPrint.Add(integers[i]);
                        }

                        Console.WriteLine(string.Join(", ", intsToPrint));
                    }
                    else if (command == "Show")
                    {
                        Console.WriteLine(integers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exceptionsCount++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exceptionsCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(string.Join(", ", integers));

        }
    }
}
