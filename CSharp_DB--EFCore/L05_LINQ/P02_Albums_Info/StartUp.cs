namespace P02_Albums_Info
{
    using P02_Albums_Info.Data;
    using P02_Albums_Info.Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            int producerId = int.Parse(Console.ReadLine());
            string result = ExportAlbumsInfo(context, producerId);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            if (context.Producers.FirstOrDefault(a => a.Id == producerId) != null)
            {
                var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    AlbumReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriter)
                        .AsEnumerable(),
                    AlbumPrice = a.Price
                })
                .AsEnumerable()
                .OrderByDescending(a => a.AlbumPrice);

                foreach (var album in albums)
                {
                    int counter = 1;
                    sb.AppendLine($"-AlbumName: {album.AlbumName}");
                    sb.AppendLine($"-ReleaseDate: {album.AlbumReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                    sb.AppendLine($"-ProducerName: {album.ProducerName}");
                    sb.AppendLine($"-Songs:");


                    foreach (var song in album.AlbumSongs)
                    {
                        sb.AppendLine($"---#{counter++}");
                        sb.AppendLine($"---SongName: {song.SongName}");
                        sb.AppendLine($"---Price: {song.SongPrice:f2}");
                        sb.AppendLine($"---Writer: {song.SongWriter}");
                    }


                    sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}