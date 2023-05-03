using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Date_Modifier
{
    public class DateModifier
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }


        public static int DaysDifference (string stringDateOne, string stringDateTwo)
        {
            int difference = 0;

            DateTime startDate = DateTime.Parse(stringDateOne);
            DateTime endDate = DateTime.Parse(stringDateTwo);

             //diff = Math.Abs((startDate.Date - endDate.Date).Days);

            TimeSpan diff = startDate - endDate;
            difference = Math.Abs(diff.Days);

            return difference;
        }

    }
}
