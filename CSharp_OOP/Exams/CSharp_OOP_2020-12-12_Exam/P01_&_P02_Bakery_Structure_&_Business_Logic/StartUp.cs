namespace Bakery
{
    using Bakery.Core;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.Tables;
    using System.Globalization;
    using System.Threading;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            //Don't forget to comment out the commented code lines in the Engine class!
            var engine = new Engine();

            engine.Run();
        }
    }
}
