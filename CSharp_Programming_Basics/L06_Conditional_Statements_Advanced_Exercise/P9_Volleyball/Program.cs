using System;

namespace _9_Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int numWeekends = int.Parse(Console.ReadLine());

            double weekendsInSofia = 48 - numWeekends;
            double weekendsInSofiaForPlay = weekendsInSofia * 3.0 / 4.0;
            double holidaysInSofia = holidays * 2.0 / 3.0;

            double play = holidaysInSofia + weekendsInSofiaForPlay + numWeekends;

            if (year == "leap")
            {
                play *= 1.15;
                Console.WriteLine(Math.Floor(play));
            }
            else
            {
                Console.WriteLine(Math.Floor(play));
            }
        }
    }
}
