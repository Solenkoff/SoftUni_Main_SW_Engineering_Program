namespace BookShop.Data
{
    internal class Configuration
    {
        internal static string ConnectionString
            => @"Server=.;Database=BookShop;User Id=sa;Password=;TrustServerCertificate=True;";
        //                            !!!                      ^--  To be inserted(password)... !!!

    }
}
