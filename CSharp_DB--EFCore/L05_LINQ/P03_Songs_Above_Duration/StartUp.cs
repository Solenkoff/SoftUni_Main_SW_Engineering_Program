namespace P03_Songs_Above_Duration
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
               new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            int duration = int.Parse(Console.ReadLine());
            string result = ExportSongsAboveDuration(context, duration);

            Console.WriteLine(result);

        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                //.Include(s => s.SongPerformers)
                //   .ThenInclude(sp => sp.Performer)
                //.Include(s => s.Album)
                //   .ThenInclude(a => a.Producer)
                //.Include(s => s.Writer)
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => new
                        {
                            PerformerFullName = sp.Performer.FirstName + " " + sp.Performer.LastName
                        })
                        .OrderBy(p => p.PerformerFullName)
                        .AsEnumerable(),
                    WriterName = s.Writer.Name,
                    AlbumProducerName = s.Album.Producer.Name,
                    SongDuration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                if (song.Performers.Any())
                {
                    foreach (var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer.PerformerFullName}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducerName}");
                sb.AppendLine($"---Duration: {song.SongDuration:c}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}