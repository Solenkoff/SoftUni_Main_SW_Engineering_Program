using System;

namespace _09_Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                //IsTheNumberPalindrome(input);
                Console.WriteLine(IsTheNumberPalindrome(input).ToString().ToLower());
                input = Console.ReadLine().ToLower();
            }

        }

        private static bool IsTheNumberPalindrome(string number)
        {
            bool isPalindrome = false;

            int numberOne = 0;
            int currentNumber = 0;
            int rem = 0;
            int rev = 0;

            currentNumber = numberOne = int.Parse(number);

            while (numberOne > 0)
            {
                rem = numberOne % 10;
                rev = rev * 10 + rem;
                numberOne = numberOne / 10;

            }

            if (rev == currentNumber)
            {
                isPalindrome = true;
            }

            return isPalindrome;
        }

    }
}
