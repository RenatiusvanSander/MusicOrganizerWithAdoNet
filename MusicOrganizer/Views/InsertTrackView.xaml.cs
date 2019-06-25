using MusicOrganizer.ViewModels;
using System.Windows;

namespace MusicOrganizer.Views
{

    /// <summary>
    /// Interaktionslogik für InsertTrackView.xaml
    /// </summary>
    public partial class InsertTrackView : Window
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public InsertTrackView()
        {
            InitializeComponent();
            insertTrackViewModel = new InsertTrackViewModel();
            DataContext = insertTrackViewModel;
        }

        private InsertTrackViewModel insertTrackViewModel;

        /// <summary>
        /// Adds arist into database.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void AddArtistButton_Click(object sender, RoutedEventArgs e)
        {
            InsertArtistView insertArtistView = new InsertArtistView();
            insertArtistView.ShowDialog();
        }

        /// <summary>
        /// Adds an album to database.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void AddAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            InsertAlbumView insertAlbumView = new InsertAlbumView();
            insertAlbumView.ShowDialog();
        }
    }
}
