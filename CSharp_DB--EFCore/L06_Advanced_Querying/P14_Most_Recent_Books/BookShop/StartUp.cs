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

            Console.WriteLine(GetMostRecentBooks(db));                           // P14

        }


        public static string GetMostRecentBooks(BookShopContext context)         // P14
        {
            var categoriesWithBooks = context.Categories
               //.Include(c => c.CategoryBooks)
               //    .ThenInclude(cb => cb.Book)
               .Select(c => new
               {
                   CategoryName = c.Name,
                   MostRecentBooks = c.CategoryBooks
                      .OrderByDescending(cb => cb.Book.ReleaseDate)
                      .Take(3)
                      .Select(cb => new
                      {
                          BookTitle = cb.Book.Title,
                          BookReleaseYear = cb.Book.ReleaseDate.Value.Year
                      })
                      .AsEnumerable()
               })
               .OrderBy(c => c.CategoryName)
               .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoriesWithBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}


