﻿using System;
using System.Collections.Generic;

namespace _01_Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);

            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
