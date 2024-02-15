namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            int lengthCheck = int.Parse(Console.ReadLine());                     // P11
            Console.WriteLine(CountBooks(db, lengthCheck)); 

        }


        public static int CountBooks(BookShopContext context, int lengthCheck)       // P11
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }

    }
}


