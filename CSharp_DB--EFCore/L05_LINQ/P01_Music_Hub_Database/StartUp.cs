namespace P01_Music_Hub_Database
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
               new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
        }
    }
}