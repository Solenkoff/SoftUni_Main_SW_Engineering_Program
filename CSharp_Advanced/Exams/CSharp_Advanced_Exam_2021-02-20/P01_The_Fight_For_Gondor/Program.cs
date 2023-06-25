using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_The_Fight_For_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {

            int waves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                                          .Split(" ")
                                          .Select(int.Parse)                                    
                                          .ToList();
            
            

            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                

                int[] orcsData = Console.ReadLine()
                                        .Split(" ")
                                        .Select(int.Parse)
                                        .ToArray();

                orcs = new Stack<int>(orcsData);

                if (i % 3 == 0)
                {
                    int[] newPlate = Console.ReadLine()
                                            .Split(" ")
                                            .Select(int.Parse)
                                            .ToArray();
                    plates.Add(newPlate[0]);
                }

                while (plates.Count > 0 && orcs.Count > 0)
                {
                    int currPlate = plates[0];
                    int currOrc = orcs.Pop();

                    if (currOrc > currPlate)
                    {
                        orcs.Push(currOrc - currPlate);
                        plates.RemoveAt(0);
                    }
                    else if (currPlate > currOrc)
                    {
                        plates[0] = (currPlate - currOrc);
                    }
                    else
                    {
                        plates.RemoveAt(0);
                    }

                }

                if (plates.Count == 0)
                {
                    break;
                }

            }

            if (orcs.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("The orcs successfully destroyed the Gondor's defense.");
                sb.Append($"Orcs left: ");
                sb.AppendLine(string.Join(", ", orcs));
                Console.WriteLine(sb.ToString());
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("The people successfully repulsed the orc's attack.");
                sb.Append($"Plates left: ");
                sb.AppendLine(string.Join(", ", plates));
                Console.WriteLine(sb.ToString());
            }

        }
    }
}
