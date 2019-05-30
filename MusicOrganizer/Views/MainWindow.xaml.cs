using MusicOrganizer.ViewModels;
using System.Windows;

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
