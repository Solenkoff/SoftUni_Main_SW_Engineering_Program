using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                Animal newAnimal = GetAnimalInfo(line);

                animals.Add(newAnimal);

                string foodDataInput = Console.ReadLine();

                Food newFood = GetFoodInfo(foodDataInput);

                Console.WriteLine(newAnimal.ProduceSound());

                try
                {
                    newAnimal.Eat(newFood);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message); 
                }               
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }


        private static Food GetFoodInfo(string foodDataInput)
        {
            string[] foodData = foodDataInput.Split();
            string foodType = foodData[0];
            int foodQuantity = int.Parse(foodData[1]);

            Food newFood = null;

            if(foodType == nameof(Vegetable))
            {
                newFood = new Vegetable(foodQuantity);
            }
            else if (foodType == nameof(Fruit))
            {
                newFood = new Fruit(foodQuantity);
            }
            else if (foodType == nameof(Meat))
            {
                newFood = new Meat(foodQuantity);
            }
            else if (foodType == nameof(Seeds))
            {
                newFood = new Seeds(foodQuantity);
            }

            return newFood;
        }


        private static Animal GetAnimalInfo(string input)
        {
            string[] animallData = input.Split();
            string type = animallData[0];
            string name = animallData[1];
            double weight = double.Parse(animallData[2]);

            Animal newAnimal = null;

            if (type == nameof(Hen))
            {
                newAnimal = new Hen(name, weight, 0, double.Parse(animallData[3]));
            }
            else if(type == nameof(Owl))
            {
                newAnimal = new Owl(name, weight, 0, double.Parse(animallData[3]));
            }
            else if(type == nameof(Mouse))
            {
                newAnimal = new Mouse(name, weight, 0, animallData[3]);
            }
            else if (type == nameof(Dog))
            {
                newAnimal = new Dog(name, weight, 0, animallData[3]);
            }
            else if (type == nameof(Cat))
            {
                newAnimal = new Cat(name, weight, 0, animallData[3], animallData[4]);
            }
            else if (type == nameof(Tiger))
            {
                newAnimal = new Tiger(name, weight, 0, animallData[3], animallData[4]);
            }

            return newAnimal;
        }

    }
}
