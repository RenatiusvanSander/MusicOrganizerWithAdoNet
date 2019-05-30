using MusicOrganizer.Models.Services;
using MusicOrganizer.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MusicOrganizer.Views
{

    /// <summary>
    /// Interaktionslogik für ShowAlbumTrackListView.xaml
    /// </summary>
    public partial class ShowAlbumTrackListView : Window
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public ShowAlbumTrackListView()
        {
            InitializeComponent();
            showAlbumTrackListViewModel = new ShowAlbumTrackListViewModel();
            DataContext = showAlbumTrackListViewModel;
        }

        /// <summary>
        /// Initializes presentation logic and properties needed for album.
        /// </summary>
        public ShowAlbumTrackListView(albums currentAlbum)
        {
            InitializeComponent();
            showAlbumTrackListViewModel =
                new ShowAlbumTrackListViewModel(currentAlbum);
            DataContext = showAlbumTrackListViewModel;
        }

        private ShowAlbumTrackListViewModel showAlbumTrackListViewModel;

        /// <summary>
        /// Plays the music file.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            showAlbumTrackListViewModel.Play(((tracks)AlbumTrackListDataGrid
                .CurrentItem).filepath);
        }

        /// <summary>
        /// Starts and shows either updateView for Artist, Album or Track.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">MouseButtonEventArgs</param>
        private void AlbumDataGrid_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var currentDatagrid = (DataGrid)e.Source;

            /* Switches through header of column title to start either
             * an update for track, artist or album. */
            switch (currentDatagrid.CurrentColumn.Header)
            {
                case "Artist":
                    {
                        UpdateArtistView updateArtistView = new UpdateArtistView(
                            (tracks)currentDatagrid.CurrentItem);
                        updateArtistView.ShowDialog();
                        break;
                    }
                case "Album":
                    {
                        UpdateAlbumView updateAlbumView = new UpdateAlbumView(
                            ((tracks)currentDatagrid.CurrentItem).albums);
                        updateAlbumView.ShowDialog();
                        break;
                    }
                default:
                    {
                        UpdateTrackView updateTrackView = new UpdateTrackView(
                            (tracks)currentDatagrid.CurrentItem);
                        updateTrackView.ShowDialog();
                        break;
                    }
            }
        }
    }
}
