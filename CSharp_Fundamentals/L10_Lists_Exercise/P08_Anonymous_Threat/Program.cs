using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Anonymous_Threat_
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> strings = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();



            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string command = commands[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    Merge(strings, startIndex, endIndex);
                }
                else if (command == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);
                    Divide(strings, index, partitions);
                }

                input = Console.ReadLine();
            }

            Console.Write(string.Join(" ", strings));

        }

        static void Divide(List<string> strings, int index, int partitions)
        {
            string element = strings[index];
            strings.RemoveAt(index);
            int length = element.Length;
            int partitionsLenght = length / partitions;
            int partLeft = length % partitions;

            List<string> tmpElement = new List<string>();

            for (int i = 0; i < partitions; i++)
            {
                string tmpParts = null;

                for (int j = 0; j < partitionsLenght; j++)
                {
                    tmpParts += element[(i * partitionsLenght) + j];
                }

                if (i == partitions - 1 && partLeft != 0)
                {
                    tmpParts += element.Substring(length - partLeft);
                }

                tmpElement.Add(tmpParts);
            }

            strings.InsertRange(index, tmpElement);
        }

        static void Merge(List<string> strings, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (endIndex > strings.Count - 1)
            {
                endIndex = strings.Count - 1;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                strings[startIndex] += strings[startIndex + 1];
                strings.RemoveAt(startIndex + 1);
            }
        }

    }
}
