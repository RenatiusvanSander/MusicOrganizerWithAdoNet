using MusicOrganizer.Models.Services;
using MusicOrganizer.ViewModels;
using System.Windows;

namespace MusicOrganizer.Views
{

    /// <summary>
    /// Interaktionslogik für UpdateTrackView.xaml
    /// </summary>
    public partial class UpdateTrackView : Window
    {

        /// <summary>
        /// Standard Ctor.
        /// </summary>
        public UpdateTrackView()
        {
            InitializeComponent();
            updateTrackViewModel = new UpdateTrackViewModel();
            DataContext = updateTrackViewModel;
        }

        /// <summary>
        /// Standard Ctor.
        /// </summary>
        public UpdateTrackView(tracks trackToUpdate)
        {
            InitializeComponent();
            updateTrackViewModel = new UpdateTrackViewModel(trackToUpdate);
            DataContext = updateTrackViewModel;
        }

        private UpdateTrackViewModel updateTrackViewModel;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void UpdateTrackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void AddAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            InsertAlbumView insertAlbumView = new InsertAlbumView();
            insertAlbumView.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void AddArtistButton_Click(object sender, RoutedEventArgs e)
        {
            InsertArtistView insertArtistView = new InsertArtistView();
            insertArtistView.ShowDialog();
        }
    }
}
