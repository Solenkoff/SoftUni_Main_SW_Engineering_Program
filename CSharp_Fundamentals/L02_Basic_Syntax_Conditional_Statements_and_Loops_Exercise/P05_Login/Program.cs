using System;

namespace P05_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            int counter = 0;
            string input = Console.ReadLine();

            while (input != password)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");

                input = Console.ReadLine();
            }
            if (input == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
