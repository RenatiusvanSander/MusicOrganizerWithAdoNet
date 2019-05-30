using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for UpdateaArtistView.
    /// </summary>
    class UpdateArtistViewModel : ViewModelBase
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public UpdateArtistViewModel() { }

        /// <summary>
        /// Ctor for a track.
        /// </summary>
        /// <param name="currentTrack">tracks</param>
        public UpdateArtistViewModel(tracks currentTrack)
        {
            InitializesMembers(currentTrack);
        }

        /* private values for properties and track info. */
        private artists currentArtist;
        private string updateName;
        private string updateHistory;
        private string updatePicture;
        private string updateWebsite;

        // Stores and changes artist's website.
        public string UpdateWebsite
        {
            get
            {
                return updateWebsite;
            }
            set
            {
                if(string.IsNullOrEmpty(updateWebsite) || !updateWebsite.Equals(value))
                {
                    updateWebsite = value;
                    ChecksAndAllowArtistUpdate();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and changes nmae of an artist.
        public string UpdateName
        {
            get
            {
                return updateName;
            }
            set
            {
                if (string.IsNullOrEmpty(updateName) || !updateName.Equals(value))
                {
                    updateName = value;
                    ChecksAndAllowArtistUpdate();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and changes history of an artist
        public string UpdateHistory
        {
            get
            {
                return updateHistory;
            }
            set
            {
                if (string.IsNullOrEmpty(updateHistory) || !updateHistory.Equals(value))
                {
                    updateHistory = value;
                    ChecksAndAllowArtistUpdate();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and changes pictures.
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
                    OnPropertyChanged();
                }
            }
        }

        // Enables or disbales button Update Artist on UpdateArtistView.
        public bool CanUpdateArtist { get; private set; }

        /// <summary>
        /// Initializes all members for databinding.
        /// </summary>
        /// <param name="currenTrack">tracks</param>
        private void InitializesMembers(tracks currentTrack)
        {
            currentArtist = currentTrack.artists;

            /* Copy artist's values into properties to fill text boxes on
             * UpdateArtistView. */
            UpdateHistory = currentArtist.History;
            UpdateName = currentArtist.Name;
            UpdatePicture = currentArtist.Picture;
            UpdateWebsite = currentArtist.Website;
        }

        /// <summary>
        /// Checks for empty strings and allows updata an artist, if all
        /// varies are filled.
        /// </summary>
        private void ChecksAndAllowArtistUpdate()
        {
            if(!string.IsNullOrEmpty(UpdateHistory) && !string.IsNullOrEmpty(UpdateName) && !string.IsNullOrEmpty(UpdatePicture) && !string.IsNullOrEmpty(UpdateWebsite))
            {
                CanUpdateArtist = true;
            }
            else
            {
                CanUpdateArtist = false;
            }

            // Updates CanUpdateArtist.
            OnPropertyChanged(nameof(CanUpdateArtist));
        }

        /// <summary>
        /// Updates artist's information.
        /// </summary>
        public void UpdateArtistInDB()
        {

            // Tries to update artist in database or throws an exception.
            try
            {
                DatabaseHandler.UpdateArtist(currentArtist.artist_id,
                    UpdateName,
                    UpdateHistory,
                    UpdatePicture,
                    UpdateWebsite);

                MessageBox.Show("Artist values have been successful updated.",
                    "Updated Artist",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch(Exception e)
            {
                ViewModelsErrorHandler(e);
            }
        }
    }
}
