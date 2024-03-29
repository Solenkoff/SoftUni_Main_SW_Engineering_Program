﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<string> items = Console.ReadLine().Split(" ").Skip(1).ToList();

            ListyIterator<string> list = new ListyIterator<string>(items);

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                }

                command = Console.ReadLine();
            }

        }
    }
}
