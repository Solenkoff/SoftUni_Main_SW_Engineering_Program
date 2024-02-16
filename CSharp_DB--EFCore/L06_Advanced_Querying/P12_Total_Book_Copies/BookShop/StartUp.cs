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

            Console.WriteLine(CountCopiesByAuthor(db));                          // P12

        }


        public static string CountCopiesByAuthor(BookShopContext context)          // P12
        {
            var result = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    AuthorFullName = string.Join(" ", a.FirstName, a.LastName),
                    CountOfBookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CountOfBookCopies)
                .ToList();

            return string.Join(Environment.NewLine, result.Select(a => $"{a.AuthorFullName} - {a.CountOfBookCopies}"));
        }

    }
}


