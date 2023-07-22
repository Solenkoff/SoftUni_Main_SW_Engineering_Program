using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Car car = new Car(333, 50);

            car.Drive(15);


            Console.WriteLine(car);
        }
    }
}
