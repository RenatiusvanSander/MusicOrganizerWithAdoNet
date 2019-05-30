using MusicOrganizer.Models.Services;
using MusicOrganizer.ViewModels;
using System.Windows;

namespace MusicOrganizer.Views
{
    /// <summary>
    /// Interaktionslogik für UpdateAlbumView.xaml
    /// </summary>
    public partial class UpdateAlbumView : Window
    {
        private UpdateAlbumViewModel updateAlbumViewModel;

        /// <summary>
        /// Standard Ctor.
        /// </summary>
        public UpdateAlbumView()
        {
            InitializeComponent();
            updateAlbumViewModel = new UpdateAlbumViewModel();
            DataContext = updateAlbumViewModel;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="rowContent">albums</param>
        public UpdateAlbumView(albums rowContent)
        {
            InitializeComponent();
            updateAlbumViewModel = new UpdateAlbumViewModel(rowContent);
            DataContext = updateAlbumViewModel;
        }

        /// <summary>
        /// Updastes an album.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">sender</param>
        private void UpdateAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            updateAlbumViewModel.UpdateAlbumInDB();
        }
    }
}
