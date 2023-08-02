using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "End")
                {
                    break;
                }

                string[] citizenData = line.Split();

                string name = citizenData[0];
                string country = citizenData[1];
                int age = int.Parse(citizenData[2]);
                
                Citizen newCitizen = new Citizen(name, country, age);

                citizens.Add(newCitizen);

            }

            foreach (var citizen in citizens)
            {
                //IPerson citizenIPerson = citizen;
                Console.WriteLine(citizen.GetName());

                IResident citizenIResident = citizen;
                Console.WriteLine(citizenIResident.GetName());
            }
        }
    }
}
