using System;

namespace _01_Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputText = Console.ReadLine();

            string newPassword = string.Empty;

            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "TakeOdd")
                {

                    for (int i = 0; i < inputText.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            newPassword += inputText[i];
                        }

                    }

                    Console.WriteLine(newPassword);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(commands[1]);
                    int lenght = int.Parse(commands[2]);

                    newPassword = newPassword.Remove(index, lenght);

                    Console.WriteLine(newPassword);

                }
                else if (command == "Substitute")
                {
                    string substring = commands[1];
                    string substitute = commands[2];

                    if (newPassword.Contains(substring))
                    {
                        newPassword = newPassword.Replace(substring, substitute);

                        Console.WriteLine(newPassword);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {newPassword}");

        }
    }
}
