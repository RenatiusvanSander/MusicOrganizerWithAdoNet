using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for UpdateAlbumView.
    /// </summary>
    class UpdateAlbumViewModel : ViewModelBase
    {

        /* private varies for properties. */
        private albums updateAlbum;
        private string updateTitle;
        private string updatePicture;
        private string updateCountTracks;

        /// <summary>
        /// Standard Ctor.
        /// </summary>
        public UpdateAlbumViewModel() { }

        /// <summary>
        /// Initializes UpdateAlbumViewModel object with an albums object.
        /// </summary>
        /// <param name="rowContent">albums</param>
        public UpdateAlbumViewModel(albums rowContent)
        {
            InitializeProperties(rowContent);
        }

        // Enables or disables Update Album Button on UpdateAlbumView.
        public bool CanUpdateAlbum { set; get; }

        // Sets and returns title.
        public string UpdateTitle
        {
            get
            {
                return updateTitle;
            }
            set
            {
                if (string.IsNullOrEmpty(updateTitle) || !updateTitle.Equals(value))
                {
                    updateTitle = value;
                    CheckAndAllowUpdate();
                    OnPropertyChanged();
                }
            }
        }

        // Sets and returns picture.
        public string UpdatePicture
        {
            get
            {
                return updatePicture;
            }
            set
            {
                if (string.IsNullOrEmpty(updatePicture) || !updatePicture.Equals(value))
                {
                    updatePicture = value;
                    CheckAndAllowUpdate();
                    OnPropertyChanged();
                }
            }
        }

        // Sets and returns number of tracks.
        public string UpdateCountTracks
        {
            get
            {
                return updateCountTracks;
            }
            set
            {
                if (string.IsNullOrEmpty(updateCountTracks) || !updateCountTracks.Equals(value))
                {
                    updateCountTracks = value;
                    CheckAndAllowUpdate();
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Checks for necessary filled properties and enables Update Album
        /// Button on UpdateAlbumView.
        /// </summary>
        private void CheckAndAllowUpdate()
        {
            if (!string.IsNullOrEmpty(UpdateTitle)
                &&
                !string.IsNullOrEmpty(UpdatePicture)
                &&
                !string.IsNullOrEmpty(UpdateCountTracks))
            {
                CanUpdateAlbum = false;
            }
            else
            {
                CanUpdateAlbum = false;
            }

            // Updates property of CanUpdateAlbum and activates button on view.
            OnPropertyChanged(nameof(CanUpdateAlbum));
        }

        /// <summary>
        /// Updates album in database via DatabaseHandler.
        /// </summary>
        public void UpdateAlbumInDB()
        {

            // Tries to update album in database.
            try
            {
                DatabaseHandler.UpdateAlbum(updateAlbum.album_id,
                    UpdateTitle,
                    UpdatePicture,
                    UpdateCountTracks);
            }
            catch (Exception e)
            {
                ViewModelsErrorHandler(e);
            }

            // Shows user a message box to inform about status.
            MessageBox.Show("Album has been successful updated.");
        }

        /// <summary>
        /// Initializes all properties for UpdateAlbumView.
        /// </summary>
        /// <param name="rowContent"></param>
        private void InitializeProperties(albums rowContent)
        {
            updateAlbum = rowContent;

            UpdateTitle = rowContent.title;
            UpdatePicture = rowContent.Picture;
            UpdateCountTracks = rowContent.TrackCount;
        }
    }
}
