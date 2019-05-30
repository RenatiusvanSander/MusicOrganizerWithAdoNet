using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// 
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public MainWindowViewModel()
        {
            LoadAlbumFromDB();
            DatabaseHandler.DatabaseUpdated += UpdateDataGrid;
        }

        private List<albums> albumToDataGrid;

        // Contains all albums to present them on DataGrid of MainWindow.
        public List<albums> AlbumToDataGrid
        {
            get
            {
                return albumToDataGrid;
            }
            set
            {
                if (albumToDataGrid != value)
                {
                    albumToDataGrid = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Updates datagrid on MainWindow when database is updated.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">e</param>
        private void UpdateDataGrid(object sender, EventArgs e)
        {
            LoadAlbumFromDB();
        }

        /// <summary>
        /// Loads all albums from database.
        /// </summary>
        private void LoadAlbumFromDB()
        {
            AlbumToDataGrid = DatabaseHandler.ReadAlbums();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentItem"></param>
        public void DeleteAlbum(albums currentItem)
        {

            // Tries to delete an album with tracks.
            try
            {
                DatabaseHandler.DeleteAlbumAndTracks(currentItem);

                MessageBox.Show($"Album {currentItem.title} has been" +
                    $" successful deleted.");
            }
            catch(Exception e)
            {
                ViewModelsErrorHandler(e);
            }
        }
    }
}
