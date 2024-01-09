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
            Tracks = new List<Track>(); bool isT = true;
            Albums = new List<Album>(); bool isA = true;
            MediaTypes = new List<MediaType>(); bool isM = true;
            Genres = new List<Genre>(); bool isG = true;

            /*
            SELECT albums.Title, tracks.TrackId
            FROM tracks
            INNER JOIN albums
            ON tracks.AlbumId = albums.AlbumId
            */

            /*
            SELECT albums.Title, tracks.TrackId                         media_types
            FROM tracks
            INNER JOIN albums
            ON tracks.AlbumId = albums.AlbumId
            */

            /*
            SELECT albums.Title, tracks.TrackId                         genres
            FROM tracks
            INNER JOIN albums
            ON tracks.AlbumId = albums.AlbumId
            */

            List<string> querys = new List<string>
            {
                "SELECT AlbumId, Title FROM albums",
                "SELECT MediaTypeId, Name FROM albums",
                "SELECT GenreId, Name FROM albums"
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
                            if (isT)
                            {
                                Tracks.Add(new Track
                                {
                                    Id = Convert.ToInt16(reader["AlbumId"]),
                                    Name = reader["Name"].ToString(),
                                    AlbumId = Convert.ToInt16(reader["AlbumId"]),
                                    MediaTypeId = Convert.ToInt16(reader["MediaTypeId"]),
                                    GenreId = Convert.ToInt16(reader["GenreId"])
                                });
                            }
                            else if (isA)
                            {
                                Albums.Add(new Album
                                {
                                    Id = Convert.ToInt16(reader["AlbumId"]),
                                    Title = reader["Title"].ToString()
                                });
                            }
                            else if (isM)
                            {
                                MediaTypes.Add(new MediaType
                                {
                                    Id = Convert.ToInt16(reader["MediaTypeId"]),
                                    Name = reader["Name"].ToString()
                                });
                            }
                            else if (isG)
                            {
                                Genres.Add(new Genre
                                {
                                    Id = Convert.ToInt16(reader["GenreId"]),
                                    Name = reader["Name"].ToString()
                                });
                            }
                        }
                        if (isT) isT = false;
                        else if (isA) isA = false;
                        else if (isM) isM = false;
                        else if (isG) isG = false;
                    }
                }
            }
        }
    }
}
