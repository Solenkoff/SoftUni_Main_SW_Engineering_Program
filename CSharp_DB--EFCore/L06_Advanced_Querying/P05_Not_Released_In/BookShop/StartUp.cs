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

            int yearInput = int.Parse(Console.ReadLine());                       // P05
            Console.WriteLine(GetBooksNotReleasedIn(db, yearInput));              

        }


        public static string GetBooksNotReleasedIn(BookShopContext context, int year)       // P05
        {
            var books = context.Books
                            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                            .Select(b => new
                            {
                                b.Title
                            })
                            .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

    }
}


