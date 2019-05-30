using MusicOrganizer.ViewModels;
using System;
using System.Linq;
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

        /// <summary>
        /// Inserts an album to database.
        /// </summary>
        /// <param name="sender">objetc</param>
        /// <param name="e">RoutedEventArgs</param>
        private void AddAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            insertAlbumViewModel.InsertAlbumIntoDB();
        }
    }
}
