using System;

namespace _04_Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {

            string password = Console.ReadLine();

            ValidOrNotPassword(password);

        }


        private static void ValidOrNotPassword(string password)
        {
            IsWithinRange(password);
            IsLetterOrDigit(password);
            HasAtLiestTwoDigits(password);

            if (IsWithinRange(password) && IsLetterOrDigit(password) && HasAtLiestTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }

        }

        private static bool IsWithinRange(string password)
        {
            bool isWithinRange = true;
            if (password.Length < 6 || password.Length > 10)
            {
                isWithinRange = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            return isWithinRange;
        }

        private static bool IsLetterOrDigit(string password)
        {
            bool isLetterOrDigit = true;
            for (int i = 0; i < password.Length; i++)
            {

                if (!char.IsLetterOrDigit(password[i]))
                {
                    isLetterOrDigit = false;
                }
            }

            if (isLetterOrDigit == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");

            }

            return isLetterOrDigit;
        }

        private static bool HasAtLiestTwoDigits(string password)
        {
            bool hasAtLiestTwoDigits = true;
            int digitsCounter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    digitsCounter++;
                }
            }

            if (digitsCounter < 2)
            {
                hasAtLiestTwoDigits = false;
                Console.WriteLine("Password must have at least 2 digits");
            }

            return hasAtLiestTwoDigits;
        }

    }
}
