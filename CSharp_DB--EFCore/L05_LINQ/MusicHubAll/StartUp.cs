namespace Music_Hub_All Database
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.Data.SqlClient.Server;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //int producerId = int.Parse(Console.ReadLine());
            //string result = ExportAlbumsInfo(context, producerId);

            int duration = int.Parse(Console.ReadLine());
            string result = ExportSongsAboveDuration(context, duration);

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

                if(song.Performers.Any())
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
