using MusicOrganizer.ViewModels;
using System.Windows;

namespace MusicOrganizer.Views
{
    /// <summary>
    /// Interaktionslogik für InsertAlbumView.xaml
    /// </summary>
    public partial class InsertAlbumView : Window
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public InsertAlbumView()
        {
            InitializeComponent();
            insertAlbumViewModel = new InsertAlbumViewModel();
            DataContext = insertAlbumViewModel;
        }

        private InsertAlbumViewModel insertAlbumViewModel;
    }
}
