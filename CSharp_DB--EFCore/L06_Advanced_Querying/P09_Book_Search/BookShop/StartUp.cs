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

            string subString = Console.ReadLine();                               // P09
            Console.WriteLine(GetBookTitlesContaining(db, subString));

        }


        public static string GetBookTitlesContaining(BookShopContext context, string subString)    // P09
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(subString.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

    }
}


