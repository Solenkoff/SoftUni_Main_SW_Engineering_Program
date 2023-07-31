using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }
        //public string Number  { get; set; }
        public void Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!"); 
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!"); 
            }
        }

        public void Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                Console.WriteLine($"Calling... {number}"); 
            }
            else
            {
                Console.WriteLine("Invalid number!"); 
            }
        }
    }
}
