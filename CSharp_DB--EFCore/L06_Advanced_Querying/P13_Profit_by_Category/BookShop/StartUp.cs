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

            Console.WriteLine(GetTotalProfitByCategory(db));                     // P13

        }


        public static string GetTotalProfitByCategory(BookShopContext context)    // P13
        {
            var categoriesProfit = context.Categories
                .Include(c => c.CategoryBooks)
                    .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryTotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.CategoryTotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            return string.Join(Environment.NewLine, categoriesProfit.Select(c => $"{c.CategoryName} ${c.CategoryTotalProfit:f2}"));
        }

    }
}


