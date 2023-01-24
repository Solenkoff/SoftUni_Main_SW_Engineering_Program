using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {

            int nPieces = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> pieces = new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i < nPieces; i++)
            {
                string[] piecesData = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = piecesData[0];
                string composer = piecesData[1];
                string key = piecesData[2];

                pieces.Add(pieceName, new Dictionary<string, string>() { { "composer", composer }, { "key", key } });
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] commands = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string piece = commands[1];

                if (command == "Add")
                {
                    string composer = commands[2];
                    string key = commands[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new Dictionary<string, string>() { { "composer", composer }, { "key", key } });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }

                }
                else if (command == "Remove")
                {

                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }
                else if (command == "ChangeKey")
                {

                    string newKey = commands[2];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece]["key"] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }

                input = Console.ReadLine();
            }

            foreach (var item in pieces.OrderBy(x => x.Key).ThenBy(z => z.Value["composer"]))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value["composer"]}, Key: {item.Value["key"]}");
            }

        }
    }
}
