using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {         

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                             
                string[] parts = Console.ReadLine().Split();
                

                if(parts.Length == 4)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];
                    string birthdate = parts[3];

                    Citizen newCitizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(name, newCitizen);
                }
                else if(parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string group = parts[2];

                    Rebel newRebel = new Rebel(name, age, group);

                    buyers.Add(name, newRebel);
                }
                          
            }

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "End")
                {
                    break;
                }

                if(buyers.ContainsKey(line))
                {
                    buyers[line].BuyFood();
                }
                else
                {
                    continue;
                }

            }

            Console.WriteLine(buyers.Values.Sum(x => x.Food));

        }
    }
}
