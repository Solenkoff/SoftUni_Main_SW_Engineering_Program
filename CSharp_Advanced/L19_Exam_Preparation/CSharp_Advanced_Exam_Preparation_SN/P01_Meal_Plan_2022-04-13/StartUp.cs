using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Meal_Plan
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> mealTypes = new Dictionary<string, int> {
                {"salad", 350 },
                {"soup", 490 },
                {"pasta", 680 },
                {"steak", 790 }
            };


            string[] mealsInput = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] caloriesInput = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

            Queue<string> meals = new Queue<string>(mealsInput);
            Stack<int> calories = new Stack<int>(caloriesInput);

            
            int mealsEaten = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {

                string currMeal = meals.Dequeue();
                int mealCalories = mealTypes[currMeal];

                int currDailyCalories = calories.Pop();

                mealsEaten++;

                if (currDailyCalories - mealCalories > 0)
                {
                    calories.Push(currDailyCalories - mealCalories);               
                }
                else
                {
                    int mealCaloriesLeft = Math.Abs(currDailyCalories - mealCalories);
                    if(calories.Count == 0)
                    {
                        break;
                    }

                    calories.Push(calories.Pop() - mealCaloriesLeft);

                }

            }

            if(meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else if(calories.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            
        }
    }
}
