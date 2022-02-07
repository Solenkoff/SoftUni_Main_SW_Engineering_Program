using System;

namespace _08_On_Time_For_The_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examH = int.Parse(Console.ReadLine());
            int examM = int.Parse(Console.ReadLine());
            int arrivedH = int.Parse(Console.ReadLine());
            int arrivedM = int.Parse(Console.ReadLine());
            examM += examH * 60;
            arrivedM += arrivedH * 60;
            int diffrence = 0;
            int min = 0;
            int hour = 0;
            if (arrivedM > examM)
            {
                Console.WriteLine("Late");
                diffrence = arrivedM - examM;
                if (diffrence < 60)
                {
                    Console.WriteLine($"{diffrence} minutes after the start");
                }
                else
                {
                    hour = diffrence / 60;
                    min = diffrence % 60;
                    Console.WriteLine($"{hour}:{min:d2} hours after the start");
                }
            }
            else if (arrivedM < examM - 30)
            {
                Console.WriteLine("Early");
                diffrence = examM - arrivedM;
                if (diffrence < 60)
                {
                    Console.WriteLine($"{diffrence} minutes before the start");
                }
                else
                {
                    hour = diffrence / 60;
                    min = diffrence % 60;
                    Console.WriteLine($"{hour}:{min:d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                diffrence = examM - arrivedM;
                Console.WriteLine($"{diffrence} minutes before the start");
            }
        }
    }
}
