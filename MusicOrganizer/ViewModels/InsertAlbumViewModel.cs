using MusicOrganizer.Models.LogicModels;
using System;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for InsertAlbumView.
    /// </summary>
    class InsertAlbumViewModel : ViewModelBase
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public InsertAlbumViewModel()
        {

        }

        /* private values of public properties */
        private string albumTitle;
        private string albumPicture;
        private string albumCountTracks;
        private string albumArtist;

        // Stores title of album.
        public string AlbumTitle
        {
            get
            {
                return albumTitle;
            }
            set
            {
                if (string.IsNullOrEmpty(albumTitle)
                    ||
                    !albumTitle.Equals(value))
                {
                    albumTitle = value;
                    CheckAndAllowAddAlbum();
                    OnPropertyChanged();
                }
            }
        }

        // Stores picture of album.
        public string AlbumPicture
        {
            get
            {
                return albumPicture;
            }
            set
            {
                if (string.IsNullOrEmpty(albumPicture)
                    ||
                    !albumPicture.Equals(value))
                {
                    albumPicture = value;
                    CheckAndAllowAddAlbum();
                    OnPropertyChanged();
                }
            }
        }

        // Stores artist of album.
        public string AlbumArtist
        {
            get
            {
                return albumArtist;
            }
            set
            {
                if (string.IsNullOrEmpty(albumArtist)
                    ||
                    !albumArtist.Equals(value))
                {
                    albumArtist = value;
                    CheckAndAllowAddAlbum();
                    OnPropertyChanged();
                }
            }
        }

        // Count the number of tracks of an album.
        public string AlbumCountTracks
        {
            get
            {
                return albumCountTracks;
            }
            set
            {
                if (string.IsNullOrEmpty(albumCountTracks)
                    ||
                    !albumCountTracks.Equals(value))
                {
                    albumCountTracks = value;
                    CheckAndAllowAddAlbum();
                    OnPropertyChanged();
                }
            }
        }

        // Enables or disables button "Add Album".
        public bool CanAddAlbum { get; private set; }

        /// <summary>
        /// Enables or disables button "Add Album" on InsertAlbumView.
        /// </summary>
        private void CheckAndAllowAddAlbum()
        {
            if (!string.IsNullOrEmpty(AlbumTitle)
                &&
                !string.IsNullOrEmpty(AlbumPicture)
                &&
                !string.IsNullOrEmpty(AlbumArtist)
                &&
                !string.IsNullOrEmpty(AlbumCountTracks))
            {
                CanAddAlbum = true;
            }
            else
            {
                CanAddAlbum = false;
            }

            // Updates property.
            OnPropertyChanged(nameof(CanAddAlbum));
        }

        /// <summary>
        /// Inserts album into database or shows an error message box.
        /// </summary>
        public void InsertAlbumIntoDB()
        {

            /* Tries to add album into database. If this fails error is
             * shown in message box to user. */
            try
            {
                DatabaseHandler.AddAlbum(AlbumArtist,
                   AlbumTitle,
                   AlbumPicture,
                   AlbumCountTracks);
            }
            catch (Exception e)
            {
                ViewModelsErrorHandler(e);
            }

            MessageBox.Show("Album has successful been added.");
        }
    }
}
