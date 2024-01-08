using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfSQLite.Modules;

namespace WpfSQLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string connectionString = "Data Source=Database\\chinook.db;Version=3";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadDate()
        {
            mainDataGrid.ItemsSource = "";
        }

        private void insertDate(object sender, RoutedEventArgs e)
        {
            string title = textbox_title.Text;
            string album = textbox_album.Text;
            string mediatype = textbox_mediatype.Text;
            string genre = textbox_genre.Text;

            if (
                !string.IsNullOrWhiteSpace(title) &&
                !string.IsNullOrWhiteSpace(album) &&
                !string.IsNullOrWhiteSpace(mediatype) &&
                !string.IsNullOrWhiteSpace(genre) )
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "";
                }
            }
        }

        private void selectDate(object sender, RoutedEventArgs e)
        {

        }

        private void saveDate(object sender, RoutedEventArgs e)
        {

        }

        private void clearDate(object sender, RoutedEventArgs e)
        {

        }
    }
    public class MainViewModel
    {

        private const string connectionString = "Data Source=Database\\chinook.db;Version=3";

        public List<Album> Albums { get; set; }
        public List<MediaType> MediaTypes { get; set; }
        public List<Genre> Genres { get; set; }

        public MainViewModel()
        {

            Albums = new List<Album>(); bool isA = true;
            MediaTypes = new List<MediaType>(); bool isM = true;
            Genres = new List<Genre>(); bool isG = true;

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

                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (isA)
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

                        if (isA) isA = false;
                        else if (isM) isM = false;
                        else if (isG) isG = false;
                    }
                }
            }
        }
    }
}
