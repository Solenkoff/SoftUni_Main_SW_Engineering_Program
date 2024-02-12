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

            Console.WriteLine(GetBooksByPrice(db));                              // P04

        }


        public static string GetBooksByPrice(BookShopContext context)            // P04
        {
            var books = context.Books
                            .Where(b => b.Price > 40)
                            .Select(b => new
                            {
                                b.Title,
                                b.Price
                            })
                            .OrderByDescending(b => b.Price)
                            .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }
    }
}


