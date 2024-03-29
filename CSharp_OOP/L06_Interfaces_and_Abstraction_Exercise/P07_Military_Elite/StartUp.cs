﻿using System;
using System.Collections.Generic;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split();
                string type = parts[0];
                string id = parts[1];
                string firstName = parts[2];
                string lastName = parts[3];


                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(parts[4]);


                    soldiersById[id] = new Private(id, firstName, lastName, salary);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    LieutenantGeneral newLieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < parts.Length; i++)
                    {
                        string privateId = parts[i];

                        if (!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        newLieutenantGeneral.AddPrivate((IPrivate)soldiersById[privateId]);
                    }

                    soldiersById[id] = newLieutenantGeneral;

                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string part = parts[i];
                        int hoursOfWork = int.Parse(parts[i + 1]);

                        IRepair repair = new Repair(part, hoursOfWork);
                        engineer.AddRepair(repair);
                    }

                    soldiersById[id] = engineer;

                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string missionCodeName = parts[i];
                        bool isValidMissionState = Enum.TryParse(parts[i + 1], out MissionState missionState);

                        if (!isValidMissionState)
                        {
                            continue;
                        }

                        IMission newMission = new Mission(missionCodeName, missionState);
                        commando.AddMission(newMission);
                    }

                    soldiersById[id] = commando;
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(parts[4]);

                    ISpy newSpy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = newSpy;
                }

            }

            foreach (var soldier in soldiersById)
            {
                Console.WriteLine(soldier.Value);
            }

        }
    }
}
