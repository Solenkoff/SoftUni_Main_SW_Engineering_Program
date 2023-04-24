﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var filterList = new List<string>();

            string filter = Console.ReadLine();

            while (filter != "Print")
            {
                string[] filterInfo = filter.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string operation = filterInfo[0];

                if (operation == "Add filter")
                {
                    filterList.Add($"{filterInfo[1]};{filterInfo[2]}");
                }
                else if (operation == "Remove filter")
                {
                    if (filterList.Contains($"{filterInfo[1]};{filterInfo[2]}"))
                    {
                        filterList.Remove($"{filterInfo[1]};{filterInfo[2]}");
                    }
                }

                filter = Console.ReadLine();
            }

            Func<string, int, bool> lengthFilter = (name, length)
                                                 => name.Length == length;
            Func<string, string, bool> startsFilter = (name, letter)
                                                    => name.StartsWith(letter);
            Func<string, string, bool> endsFilter = (name, letter)
                                                  => name.EndsWith(letter);
            Func<string, string, bool> containsFilter = (name, letter)
                                                      => name.Contains(letter);

            foreach (var currentFilter in filterList)
            {
                string[] currentFilterInfo = currentFilter.Split(";", StringSplitOptions.RemoveEmptyEntries)
                    ;

                string action = currentFilterInfo[0];
                string parameter = currentFilterInfo[1];

                if (action == "Starts with")
                {
                    names = names.Where(name => !startsFilter(name, parameter))
                                 .ToArray();
                }
                else if (action == "Ends with")
                {
                    names = names.Where(name => !endsFilter(name, parameter))
                                 .ToArray();
                }
                else if (action == "Length")
                {
                    names = names.Where(name => !lengthFilter(name, int.Parse(parameter)))
                                 .ToArray();

                }
                else if (action == "Contains")
                {
                    names = names.Where(name => !containsFilter(name, parameter))
                                 .ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", names));

        }
    }
}
