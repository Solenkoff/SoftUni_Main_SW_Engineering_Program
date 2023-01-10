using System;
using System.Linq;

namespace P01_Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {

            string message = Console.ReadLine();

            string input = Console.ReadLine();

            while(input != "Reveal")
            {
                string[] messageData = input.Split(":|:");

                string command = messageData[0];

                if(command == "InsertSpace")
                {
                    int index = int.Parse(messageData[1]);

                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    string subString = messageData[1];

                    if (message.Contains(subString))
                    {
                        char[] charArray = subString.ToCharArray();
                        Array.Reverse(charArray);
                        string reversed = new string(charArray);

                        int index = message.IndexOf(subString);
                        message = message.Remove(index, subString.Length);

                        message += reversed;

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string subString = messageData[1];
                    string replacement = messageData[2];

                    message = message.Replace(subString, replacement);

                    Console.WriteLine(message);
                }

                

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
