namespace Heroes.IO
{
    using System;
    using IO.Contracts;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
