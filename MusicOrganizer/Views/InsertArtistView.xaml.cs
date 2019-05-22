using System.Windows;
using MusicOrganizer.ViewModels;

namespace MusicOrganizer.Views
{
    /// <summary>
    /// Interaktionslogik für InsertArtistView.xaml
    /// </summary>
    public partial class InsertArtistView : Window
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public InsertArtistView()
        {
            InitializeComponent();
            insertArtistViewModel = new InsertArtistViewModel();
            DataContext = insertArtistViewModel;
        }

        private InsertArtistViewModel insertArtistViewModel;

        /// <summary>
        /// Inserts an artist on button click "Add Artist" into database table
        /// artist.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void InsertArtistIntoDB_Click(object sender, RoutedEventArgs e)
        {
            insertArtistViewModel.InsertArtistIntoDB();
        }
    }
}
