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
    }
}
