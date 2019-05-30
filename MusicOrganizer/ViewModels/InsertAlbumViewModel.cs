using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Collections.Generic;
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
            InitializesArtists();
        }

        /* private values of public properties */
        private string albumTitle;
        private string albumPicture;
        private string albumCountTracks;
        private List<string> artistsList;
        private string selectedArtist;

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
        public List<string> Artists
        {
            get
            {
                return artistsList;
            }
            set
            {
                if (artistsList == null || artistsList != value)
                {
                    artistsList = value;
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

        // Stores the selected artist from InsertAlbumView.
        public string SelectedArtist
        {
            get
            {
                return selectedArtist;
            }
            set
            {
                if (string.IsNullOrEmpty(selectedArtist) || !selectedArtist.Equals(value))
                {
                    selectedArtist = value;
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
                !string.IsNullOrEmpty(SelectedArtist)
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
        /// Initializes Artists property for the combobox.
        /// </summary>
        private void InitializesArtists()
        {
            List<string> artistsNames = new List<string>();

            // Tries to fill artistsNames. Or throw an error.
            try
            {
                foreach(var artist in DatabaseHandler.ReadArtists().ToArray())
                {
                    artistsNames.Add(artist.Name);
                }
            }
            catch(Exception e)
            {
                ViewModelsErrorHandler(e);
            }

            // Copy values.
            Artists = artistsNames;
            SelectedArtist = Artists.ToArray()[0];
        }

        /// <summary>
        /// Inserts album into database or shows an error message box.
        /// </summary>
        public void InsertAlbumIntoDB()
        {

            /* Tries to add album into database. If this fails error is
             * shown in a message box to user. */
            try
            {
                DatabaseHandler.AddAlbum(SelectedArtist,
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
