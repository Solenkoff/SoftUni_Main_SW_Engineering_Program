using System;

namespace _01_The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            string message = Console.ReadLine();


            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] commands = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Move")
                {
                    int numLetters = int.Parse(commands[1]);
                    string beginning = message.Substring(0, numLetters);
                    message = message.Remove(0, numLetters);
                    message = message + beginning;

                }
                if (command == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    string toInsert = commands[2];

                    message = message.Substring(0, index) + toInsert + message.Substring(index);
                }
                if (command == "ChangeAll")
                {
                    string toReplace = commands[1];
                    string replacement = commands[2];

                    message = message.Replace(toReplace, replacement);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");

        }
    }
}
