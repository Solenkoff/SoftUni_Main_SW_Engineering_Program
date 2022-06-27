using System;

namespace P01_Encrypt_Sort_And_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> vowels = new List<char>
            {
                'a','A',
                'e','E',
                'i','I',
                'o','O',
                'u','U'
            };


            int linesCount = int.Parse(Console.ReadLine());
            int[] sumOfAll = new int[linesCount];
            for (int i = 0; i < linesCount; i++)
            {
                string word = Console.ReadLine();
                int sum = 0;

                for (int k = 0; k < word.Length; k++)
                {
                    if (vowels.Contains(word[k]))
                    {
                        sum += (int)word[k] * word.Length;

                    }
                    else
                    {
                        sum += (int)(word[k] / word.Length);
                    }

                }

                sumOfAll[i] = sum;
            }


            var listOfSum = sumOfAll.ToList();
            var listWithoutZero = listOfSum.Where(x => x != 0);
            var orderedList = listWithoutZero.OrderBy(x => x);
            foreach (var item in orderedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
