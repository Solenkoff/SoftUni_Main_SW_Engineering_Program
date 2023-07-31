using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> urls = Console.ReadLine().Split().ToList();




            foreach (var item in numbers)
            {
                if(item.Length == 10)
                {
                    ICallable smartphone = new Smartphone();
                    smartphone.Call(item);
                }
                else
                {
                    ICallable stationaryPhone = new StationaryPhone();
                    stationaryPhone.Call(item);
                }
            }

            foreach (var item in urls)
            {
                IBrowsable smartphone = new Smartphone();
                smartphone.Browse(item);
            }

        }
    }
}
