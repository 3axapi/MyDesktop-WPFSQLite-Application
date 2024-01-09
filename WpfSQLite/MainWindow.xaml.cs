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
using WpfSQLite;
using System.Windows.Controls.Primitives;

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
            DataContext = new MainViewModel();
            loadDate();
        }

        private void loadDate()
        {
            mainDataGrid.ItemsSource = ((MainViewModel)DataContext).Tracks
                .Join(((MainViewModel)DataContext).Albums,
                trakc => trakc.Id,
                album => album.TrackId,
                (track, album) => new
                {
                    track.Id,
                    track.Name,
                    album.ATitle
                })
                .Join(((MainViewModel)DataContext).MediaTypes,
                trackWithAlbum => trackWithAlbum.Id,
                mediaType => mediaType.TrackId,
                (trackWithAlbum, mediaType) => new
                {
                    trackWithAlbum.Id,
                    trackWithAlbum.Name,
                    trackWithAlbum.ATitle,
                    mediaType.MName
                })
                .Join(((MainViewModel)DataContext).Genres,
                trackWithAlbum => trackWithAlbum.Id,
                genre => genre.TrackId,
                (trackWithAlbum, genre) => new
                {
                    trackWithAlbum.Id,
                    trackWithAlbum.Name,
                    trackWithAlbum.ATitle,
                    trackWithAlbum.MName,
                    genre.GName
                }).ToList();
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
}
