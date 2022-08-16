using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUni_Course_Planning_
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> schedule = Console.ReadLine()
                                       .Split(", ")
                                       .ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] comands = input.Split(':', StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();
                string comand = comands[0];
                string lessonTitle = comands[1];

                if (comand == "Add")
                {
                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                    }
                }
                else if (comand == "Insert")
                {
                    int index = int.Parse(comands[2]);
                    if (index >= 0 && index < schedule.Count)
                    {
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Insert(index, lessonTitle);
                        }
                    }
                }
                else if (comand == "Remove")
                {
                    schedule.Remove(lessonTitle);
                }
                else if (comand == "Swap")
                {
                    string firstLessonTitle = comands[1];
                    string secondLessonTitle = comands[2];

                    int firstLessonIndex = schedule.IndexOf(firstLessonTitle);
                    int secondLessonIndex = schedule.IndexOf(secondLessonTitle);

                    if (firstLessonIndex != -1 && secondLessonIndex != -1)
                    {
                        schedule[firstLessonIndex] = secondLessonTitle;
                        schedule[secondLessonIndex] = firstLessonTitle;

                        string firstLessonExercise = $"{firstLessonTitle}-Exercise";
                        int firstLessonExerciseIndex = schedule.IndexOf(firstLessonExercise);
                        string secondLessonExercise = $"{secondLessonTitle}-Exercise";
                        int secondLessonExerciseIndex = schedule.IndexOf(secondLessonExercise);

                        if (schedule.Contains(firstLessonExercise))
                        {
                            schedule.Remove(firstLessonExercise);
                            schedule.Insert(schedule.IndexOf(firstLessonTitle) + 1, firstLessonExercise);
                        }
                        if (schedule.Contains(secondLessonExercise))
                        {
                            schedule.Remove(secondLessonExercise);
                            schedule.Insert(schedule.IndexOf(secondLessonTitle) + 1, secondLessonExercise);
                        }
                    }

                }
                else if (comand == "Exercise")
                {
                    int index = schedule.IndexOf(lessonTitle);
                    string exercise = $"{lessonTitle}-Exercise";

                    bool isThereLesson = schedule.Contains(lessonTitle);
                    bool isThereExercise = schedule.Contains(exercise);

                    if (isThereLesson && !isThereExercise)
                    {
                        schedule.Insert(index + 1, $"{lessonTitle}-Exercise");
                    }
                    else if (!isThereLesson)
                    {
                        schedule.Add(lessonTitle);
                        schedule.Add(exercise);
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }

        }
    }
}
