namespace P01_Square_Root
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());

                if(num < 0)
                {
                    throw new ArgumentException("Invalid number.");  // InvalidNumException
                }

                double sqrRootOfNum = Math.Sqrt(num);
                Console.WriteLine(sqrRootOfNum);
            }
            catch (ArgumentException ex)                        // InvalidNumException
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
