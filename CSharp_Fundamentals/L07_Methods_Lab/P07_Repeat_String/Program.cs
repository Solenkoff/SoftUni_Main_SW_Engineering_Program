using System;

namespace _07_Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            RepeatString(text, n);

        }


        private static void RepeatString(string str, int count)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(str);
            }

            Console.WriteLine(result.ToString());
        }

    }
}
