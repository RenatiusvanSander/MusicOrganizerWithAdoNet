using MusicOrganizer.Models.Services;
using MusicOrganizer.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MusicOrganizer.Views
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
        }

        private MainWindowViewModel mainWindowViewModel;

        /// <summary>
        /// Shows InsertArtistView to let user add an artist.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ShowInseretArtistView_Click(object sender,
            RoutedEventArgs e)
        {
            InsertArtistView insertArtistView = new InsertArtistView();
            insertArtistView.ShowDialog();
        }

        /// <summary>
        /// Shows InsertAlbumView to let user add an artist.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void ShowInsertAlbumView_Click(object sender,
            RoutedEventArgs e)
        {
            InsertAlbumView insertAlbumView = new InsertAlbumView();
            insertAlbumView.ShowDialog();
        }

        /// <summary>
        /// Shows InsertTrackView to let user add a track.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void AddTrackButton_Click(object sender, RoutedEventArgs e)
        {
            InsertTrackView insertTrackView = new InsertTrackView();
            insertTrackView.ShowDialog();
        }

        /// <summary>
        /// Starts either edit view for UpdateAlbumView or UpdateArtistView.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">MouseButtonEventArgs</param>
        private void AlbumDataGrid_Click(object sender,
            System.Windows.Input.MouseButtonEventArgs e)
        {
            var currentRow = ((DataGrid)e.Source).CurrentCell.Item;

            /* This switch detects if UpdateArtistView via artist header
             * or UpdateAlbumView is to start. */
            switch (((DataGrid)e.Source).CurrentColumn.Header)
            {

                // Starts UpdateArtistView.
                case "Artist":
                    {
                        UpdateArtistView updateArtistView = new UpdateArtistView();
                        updateArtistView.ShowDialog();
                        break;
                    }

                //Starts ShowAlbumTrackListView.
                case "Title":
                    {
                        ShowAlbumTrackListView showAlbumTrackListView = new ShowAlbumTrackListView((albums)currentRow);
                        showAlbumTrackListView.ShowDialog();
                        break;
                    }

                // Starts UpdateAlbumView.
                default:
                    {
                        UpdateAlbumView updateAlbum = new UpdateAlbumView((albums)currentRow);
                        updateAlbum.ShowDialog();
                        break;
                    }
            }
        }

        /// <summary>
        /// Inserts a new album.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void InsertAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            InsertAlbumView insertAlbumView = new InsertAlbumView();
            insertAlbumView.ShowDialog();
        }

        /// <summary>
        /// Updates an album.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void UpdateAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateAlbumView updateAlbumView = new UpdateAlbumView((albums)AlbumDataGrid.CurrentItem);
            updateAlbumView.ShowDialog();
        }

        /// <summary>
        /// Deletes an album and belonging tracks.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void DeleteAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.DeleteAlbum((albums)AlbumDataGrid.CurrentItem);
        }
    }
}
