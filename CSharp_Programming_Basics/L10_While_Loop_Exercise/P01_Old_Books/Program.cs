using System;

namespace _01_Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookToBeFound = Console.ReadLine();
            string bookName = Console.ReadLine();
            int bookCounter = 0;
            while (bookName != "No More Books")
            {
                if (bookName == bookToBeFound)
                {
                    Console.WriteLine($"You checked {bookCounter} books and found it.");
                    break;
                }
                bookCounter++;
                bookName = Console.ReadLine();
            }
            if (bookToBeFound != bookName)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookCounter} books.");
            }
        }
    }
}
