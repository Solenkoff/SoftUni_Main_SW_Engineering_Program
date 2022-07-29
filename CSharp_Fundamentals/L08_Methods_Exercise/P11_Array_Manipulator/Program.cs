using System;
using System.Linq;

namespace _11_Array_Manipulator_
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] comand = input.Split();


                if (comand[0] == "exchange")
                {
                    int index = int.Parse(comand[1]);

                    if (index < 0 || index > arr.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    Exchange(arr, index);
                }
                else if (comand[0] == "max")
                {
                    if (comand[1] == "even")
                    {
                        if (MaxEven(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(MaxEven(arr));
                    }
                    else if (comand[1] == "odd")
                    {
                        if (MaxOdd(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(MaxOdd(arr));
                    }
                }
                else if (comand[0] == "min")
                {
                    if (comand[1] == "even")
                    {
                        if (MinEven(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinEven(arr));
                    }
                    else if (comand[1] == "odd")
                    {
                        if (MinOdd(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinOdd(arr));
                    }
                }
                else if (comand[0] == "first")
                {
                    int count = int.Parse(comand[1]);

                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    else if (comand[2] == "even")
                    {
                        FirstCountEven(arr, count);
                    }
                    else if (comand[2] == "odd")
                    {
                        FirstCountOdd(arr, count);
                    }
                }
                else if (comand[0] == "last")
                {
                    int count = int.Parse(comand[1]);

                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    else if (comand[2] == "even")
                    {
                        LastCountEven(arr, count);
                    }
                    else if (comand[2] == "odd")
                    {
                        LastCountOdd(arr, count);
                    }
                }
            }

            Console.WriteLine("[" + String.Join(", ", arr) + "]");

        }

        static void LastCountOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result) + "]");
            }
        }

        static void LastCountEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result) + "]");
            }
        }

        static void FirstCountOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result) + "]");
            }
        }
        static void FirstCountEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result) + "]");
            }
        }

        static int MinOdd(int[] arrey)
        {
            int minOddNum = int.MaxValue;
            int minOddNumIndex = -1;

            for (int i = 0; i < arrey.Length; i++)
            {
                if (arrey[i] % 2 != 0 && arrey[i] <= minOddNum)
                {
                    minOddNum = arrey[i];
                    minOddNumIndex = i;
                }

            }
            return minOddNumIndex;
        }

        static int MinEven(int[] arrey)
        {
            int minEvenNum = int.MaxValue;
            int minEvenNumIndex = -1;

            for (int i = 0; i < arrey.Length; i++)
            {
                if (arrey[i] % 2 == 0 && arrey[i] <= minEvenNum)
                {
                    minEvenNum = arrey[i];
                    minEvenNumIndex = i;
                }

            }
            return minEvenNumIndex;
        }
        static int MaxOdd(int[] arrey)
        {
            int maxOddNum = int.MinValue;
            int maxOddNumIndex = -1;
            for (int i = 0; i < arrey.Length; i++)
            {
                if (arrey[i] % 2 != 0)
                {
                    if (arrey[i] >= maxOddNum)
                    {
                        maxOddNum = arrey[i];
                        maxOddNumIndex = i;
                    }
                }
            }

            return maxOddNumIndex;
        }

        static int MaxEven(int[] arrey)
        {
            int maxEvenNum = int.MinValue;
            int maxEvenNumIndex = -1;
            for (int i = 0; i < arrey.Length; i++)
            {
                if (arrey[i] % 2 == 0)
                {
                    if (arrey[i] >= maxEvenNum)
                    {
                        maxEvenNum = arrey[i];
                        maxEvenNumIndex = i;
                    }
                }
            }

            return maxEvenNumIndex;
        }

        static void Exchange(int[] arrey, int index)
        {
            int[] firstArr = new int[arrey.Length - index - 1];
            int[] secondArr = new int[index + 1];

            int firstArrIndex = 0;
            for (int i = index + 1; i < arrey.Length; i++)
            {
                firstArr[firstArrIndex] = arrey[i];
                firstArrIndex++;
            }

            for (int i = 0; i < index + 1; i++)
            {
                secondArr[i] = arrey[i];
            }

            for (int i = 0; i < firstArr.Length; i++)
            {
                arrey[i] = firstArr[i];
            }

            for (int i = 0; i < secondArr.Length; i++)
            {
                arrey[firstArr.Length + i] = secondArr[i];
            }
        }

    }
}
