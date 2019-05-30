using MusicOrganizer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
