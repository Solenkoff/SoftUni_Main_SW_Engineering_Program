using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_ForceBook_
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> forces = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                string forceSide = string.Empty;
                string forceUser = string.Empty;

                if (input.Contains('|'))
                {
                    string[] inputData = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    forceSide = inputData[0];
                    forceUser = inputData[1];
                    bool doesForceUserExist = false;

                    foreach (var item in forces)
                    {
                        if (item.Value.Contains(forceUser))
                        {
                            doesForceUserExist = true;
                        }
                    }
                    if (doesForceUserExist == false)
                    {
                        if (forces.ContainsKey(forceSide))
                        {
                            forces[forceSide].Add(forceUser);
                        }
                        else
                        {
                            forces.Add(forceSide, new List<string> { forceUser });
                        }
                    }


                }
                else
                {
                    string[] inputData = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    forceSide = inputData[1];
                    forceUser = inputData[0];

                    bool doesForceUserExist = false;
                    string theOtherSide = string.Empty;

                    foreach (var item in forces)
                    {
                        if (item.Value.Contains(forceUser))
                        {
                            doesForceUserExist = true;
                        }
                    }
                    if (doesForceUserExist == false)
                    {
                        if (forces.ContainsKey(forceSide))
                        {
                            forces[forceSide].Add(forceUser);
                        }
                        else
                        {
                            forces.Add(forceSide, new List<string> { forceUser });
                        }
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else if (doesForceUserExist == true)
                    {
                        foreach (var item in forces)
                        {
                            if (!item.Value.Contains(forceUser))
                            {
                                item.Value.Add(forceUser);

                            }
                            else if (item.Value.Contains(forceUser))
                            {
                                item.Value.Remove(forceUser);
                            }
                            Console.WriteLine($"{forceUser} joins the {item.Key} side!");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var force in forces.Where(x => x.Value.Count > 0)
                                        .OrderByDescending(x => x.Value.Count)
                                        .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
                foreach (var item in force.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }

        }
    }
}
