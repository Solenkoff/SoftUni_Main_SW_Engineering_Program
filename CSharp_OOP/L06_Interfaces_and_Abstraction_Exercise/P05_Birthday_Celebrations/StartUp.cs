using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "End")
                {
                    break;
                }

                string[] parts = line.Split();
                string command = parts[0];

                if(command == "Citizen")
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];

                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if(command == "Pet")
                {
                    string name = parts[1];
                    string birthdate = parts[2];

                    birthables.Add(new Pet(name, birthdate));
                }
                else if(command == "Robot")
                {
                    continue;
                }
            
            }

            string filter = Console.ReadLine();

            List<IBirthable> filtered = birthables.Where(x => x.Birthdate.EndsWith(filter)).ToList();

            foreach (var item in filtered)
            {
                Console.WriteLine(item.Birthdate);
            }

        }
    }
}
