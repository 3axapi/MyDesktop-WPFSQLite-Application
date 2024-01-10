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
using System.Diagnostics.Metrics;

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
        }

        private void selectData(object sender, RoutedEventArgs e)
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
                trackWithAlbumAndMedia => trackWithAlbumAndMedia.Id,
                genre => genre.TrackId,
                (trackWithAlbumAndMedia, genre) => new
                {
                    trackWithAlbumAndMedia.Id,
                    trackWithAlbumAndMedia.Name,
                    trackWithAlbumAndMedia.ATitle,
                    trackWithAlbumAndMedia.MName,
                    genre.GName
                }).ToList();
        }

        private void clearData(object sender, RoutedEventArgs e)
        {
            mainDataGrid.ItemsSource = null;
        }
    }
}
