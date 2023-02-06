using System;

namespace _01_String_Changes
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputString = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Translate")
                {
                    string toBeReplaced = commands[1].ToString();
                    string replacement = commands[2].ToString();
                    inputString = inputString.Replace(toBeReplaced, replacement);

                    Console.WriteLine(inputString);
                }
                else if (commands[0] == "Includes")
                {
                    string existingString = commands[1];
                    bool doesItExist = inputString.Contains(existingString);
                    Console.WriteLine(doesItExist);
                }
                else if (commands[0] == "Start")
                {
                    string matchingBegining = commands[1];
                    string beginingOFString = inputString.Substring(0, matchingBegining.Length);
                    bool doesMatch = beginingOFString == matchingBegining;
                    Console.WriteLine(doesMatch);
                }
                else if (commands[0] == "Lowercase")
                {
                    inputString = inputString.ToLower();
                    Console.WriteLine(inputString);
                }
                else if (commands[0] == "FindIndex")
                {
                    string lastOccurence = commands[1];
                    Console.WriteLine(inputString.LastIndexOf(lastOccurence));
                }
                else if (commands[0] == "Remove")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);

                    inputString = inputString.Remove(startIndex, count);
                    Console.WriteLine(inputString);
                }

                input = Console.ReadLine();
            }

        }
    }
}
