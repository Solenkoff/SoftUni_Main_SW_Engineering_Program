using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01_Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                                                      .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(int.Parse)
                                                      .ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                                                      .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(int.Parse)
                                                      .ToArray());

            int wreaths = 0;
            int storedFlowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currLilies = lilies.Pop();
                int currRoses = roses.Peek();


                if(currLilies + currRoses == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                }
                else if (currLilies + currRoses > 15)
                {
                    lilies.Push(currLilies - 2);
                    continue;
                }
                else
                {
                    storedFlowers += currLilies + roses.Dequeue();
                }
            }

            if(storedFlowers > 15)
            {
                wreaths += storedFlowers / 15;
            }

            if(wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }


        }
    }
}
