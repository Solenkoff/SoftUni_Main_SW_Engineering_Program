namespace P01_Reverse_Strings
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            while (text != "end")
            {
                string revesedText = string.Empty;

                for (int i = text.Length - 1; i >= 0; i--)
                {
                    revesedText += text[i];
                }

                Console.WriteLine($"{text} = {revesedText}");

                text = Console.ReadLine();
            }

        }
    }
}
