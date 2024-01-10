using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfSQLite.Modules;

namespace WpfSQLite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public class MainViewModel
    {
        private const string connectionString = "Data Source=Database\\chinook.db;Version=3";

        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<MediaType> MediaTypes { get; set; }
        public List<Genre> Genres { get; set; }

        public MainViewModel()
        {
            Tracks = new List<Track>();
            Albums = new List<Album>();
            MediaTypes = new List<MediaType>();
            Genres = new List<Genre>();

            List<string> querys = new List<string>
            {
                "SELECT TrackId, Name, AlbumId, MediaTypeId, GenreId" +
                    " FROM tracks" +
                    " LIMIT 6",
                "SELECT albums.Title, tracks.TrackId" +
                    " FROM tracks" +
                    " INNER JOIN albums" +
                    " ON tracks.AlbumId = albums.AlbumId",
                "SELECT media_types.Name, tracks.TrackId" +
                    " FROM tracks" +
                    " INNER JOIN media_types" +
                    " ON tracks.MediaTypeId = media_types.MediaTypeId",
                "SELECT genres.Name, tracks.TrackId" +
                    " FROM tracks" +
                    " INNER JOIN genres" +
                    " ON tracks.GenreId = genres.GenreId"
            };

            foreach (string query in querys)
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (query == querys[0])
                            {
                                Tracks.Add(new Track
                                {
                                    Id = Convert.ToInt16(reader["TrackId"]),
                                    Name = reader["Name"].ToString(),
                                    AlbumId = Convert.ToInt16(reader["AlbumId"]),
                                    MediaTypeId = Convert.ToInt16(reader["MediaTypeId"]),
                                    GenreId = Convert.ToInt16(reader["GenreId"])
                                });
                            }
                            else if (query == querys[1])
                            {
                                Albums.Add(new Album
                                {
                                    ATitle = reader["Title"].ToString(),
                                    TrackId = Convert.ToInt16(reader["TrackId"]),
                                });
                            }
                            else if (query == querys[2])
                            {
                                MediaTypes.Add(new MediaType
                                {
                                    MName = reader["Name"].ToString(),
                                    TrackId = Convert.ToInt16(reader["TrackId"])
                                });
                            }
                            else if (query == querys[3])
                            {
                                Genres.Add(new Genre
                                {
                                    GName = reader["Name"].ToString(),
                                    TrackId = Convert.ToInt16(reader["TrackId"])
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}
