using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Snake snake = new Snake(name);

            Console.WriteLine(snake);

        }
    }
}
