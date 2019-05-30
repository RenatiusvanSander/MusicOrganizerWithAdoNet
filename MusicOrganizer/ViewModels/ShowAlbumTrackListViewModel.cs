using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for ShowAlbumTrackListView.
    /// </summary>
    public class ShowAlbumTrackListViewModel : ViewModelBase
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public ShowAlbumTrackListViewModel()
        { }

        /// <summary>
        /// Ctor.
        /// </summary>
        public ShowAlbumTrackListViewModel(albums actualAlbum)
        {
            currentAlbum = actualAlbum;
            AlbumPicture = actualAlbum.Picture;
            InitializeDatagridItemsSource();
        }

        /* Stores album id for entity framework query to show user a list
         * of album tracks. */
        private albums currentAlbum;
        private List<tracks> datagridItemsSource;
        private string albumPicture;

        /* Stores all tracks of an album for DataGrid on
         * ShowAlbumTrackListView. */
        public List<tracks> DataGridItemsSource
        {
            get
            {
                return datagridItemsSource;
            }
            set
            {
                if (datagridItemsSource == null || datagridItemsSource != value)
                {
                    datagridItemsSource = value;
                    OnPropertyChanged();
                }
            }
        }

        // Store album picture for ShowAlbumTrackListView.
        public string AlbumPicture
        {
            get
            {
                return albumPicture;
            }
            set
            {
                if(string.IsNullOrEmpty(albumPicture)
                    ||
                    !albumPicture.Equals(albumPicture))
                {
                    albumPicture = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Initializes ItemSources for the datagrid on ShowAlbumTrackListView.
        /// </summary>
        private void InitializeDatagridItemsSource()
        {

            // Tries to get a list of tracks from specific album.
            try
            {
                DataGridItemsSource = DatabaseHandler
                    .ReadAlbumTracks(currentAlbum.album_id);
            }
            catch (Exception e)
            {
                ViewModelsErrorHandler(e);
            }
        }

        /// <summary>
        /// Plays a music-file via player.
        /// </summary>
        /// <param name="filePath">string</param>
        public void Play(string filePath)
        {
            Process.Start(filePath);
        }
    }
}
