using MusicOrganizer.Models.Services;
using MusicOrganizer.ViewModels;
using System.Windows;

namespace MusicOrganizer.Views
{

    /// <summary>
    /// Interaktionslogik für UpdateArtistView.xaml
    /// </summary>
    public partial class UpdateArtistView : Window
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public UpdateArtistView()
        {
            InitializeComponent();
            updateArtistViewModel = new UpdateArtistViewModel();
            DataContext = updateArtistViewModel;
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public UpdateArtistView(tracks currentTrack)
        {
            InitializeComponent();
            updateArtistViewModel = new UpdateArtistViewModel(currentTrack);
            DataContext = updateArtistViewModel;
        }

        private UpdateArtistViewModel updateArtistViewModel;

        /// <summary>
        /// Updates artist after a click on button.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">sender</param>
        private void UpdateArtistButton_Click(object sender, RoutedEventArgs e)
        {
            updateArtistViewModel.UpdateArtistInDB();
        }
    }
}
