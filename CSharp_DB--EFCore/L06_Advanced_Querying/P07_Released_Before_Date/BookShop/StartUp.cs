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

            string date = Console.ReadLine();                                    // P07
            Console.WriteLine(GetBooksReleasedBefore(db, date));

        }


        public static string GetBooksReleasedBefore(BookShopContext context, string date)   // P07
        {
            DateTime givenDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                        .Where(b => b.ReleaseDate < givenDate)
                        .Select(b => new
                        {
                            b.Title,
                            b.EditionType,
                            b.Price,
                            b.ReleaseDate
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .ToList();

            return string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }

    }
}


