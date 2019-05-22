using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for InsertArtistView.
    /// </summary>
    public class InsertArtistViewModel : ViewModelBase
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public InsertArtistViewModel()
        {

        }

        /* private varies for properties */
        private string artistName;
        private string artistHistory;
        private string artistPicture;
        private string artistWebsite;

        /* public properties for InsertArtistView */

        // Stores and updates property ArtistName.
        public string ArtistName
        {
            set
            {
                if (string.IsNullOrEmpty(artistName)
                    ||
                    !artistName.Equals(value))
                {
                    artistName = value;
                    CheckAndAllowInsertArtistIntoDB();
                    OnPropertyChanged();
                }
            }
            get
            {
                return artistName;
            }
        }

        // Stores and updates property ArtistHistory.
        public string ArtistHistory
        {
            set
            {
                if (string.IsNullOrEmpty(artistHistory)
                    ||
                    !artistHistory.Equals(value))
                {
                    artistHistory = value;
                    CheckAndAllowInsertArtistIntoDB();
                    OnPropertyChanged();
                }
            }
            get
            {
                return artistHistory;
            }
        }

        // Stores and updates property ArtistPicture.
        public string ArtistPicture
        {
            set
            {
                if (string.IsNullOrEmpty(artistPicture)
                    ||
                    !artistPicture.Equals(value))
                {
                    artistPicture = value;
                    CheckAndAllowInsertArtistIntoDB();
                    OnPropertyChanged();
                }
            }
            get
            {
                return artistPicture;
            }
        }

        // Stores and updates property ArtistWebsite.
        public string ArtistWebsite
        {
            set
            {
                if (string.IsNullOrEmpty(artistWebsite)
                    ||
                    !artistWebsite.Equals(value))
                {
                    artistWebsite = value;
                    CheckAndAllowInsertArtistIntoDB();
                    OnPropertyChanged();
                }
            }
            get
            {
                return artistWebsite;
            }
        }

        // Enables or diasbles Add artist Button on InsertArtistView.
        public bool CanInsertArtistIntoDB { get; private set; }

        /// <summary>
        /// Enables button Add Artist on InsertArtistView. Four properties
        /// have to be values to change button to IsEnabled.
        /// </summary>
        private void CheckAndAllowInsertArtistIntoDB()
        {

            /* Checks for all strings are not null or empty and sets
             * CanInsertArtistIntoDB to true or false. True activates
             * the button on InsertArtistView. */
            if (!string.IsNullOrEmpty(ArtistName)
                &&
                !string.IsNullOrEmpty(ArtistHistory)
                &&
                !string.IsNullOrEmpty(ArtistPicture)
                &&
                !string.IsNullOrEmpty(ArtistWebsite))
            {
                CanInsertArtistIntoDB = true;
            }
            else
            {
                CanInsertArtistIntoDB = false;
            }

            // Update property CanInsertArtistIntoDB.
            OnPropertyChanged(nameof(CanInsertArtistIntoDB));
        }

        /// <summary>
        /// Inserts artist into databse. DatabaseHandler is doing that for us.
        /// </summary>
        public void InsertArtistIntoDB()
        {
            artists artist = new artists()
            {
                Name = artistName,
                History = artistHistory,
                Picture = artistPicture,
                Website = artistWebsite,
            };

            /* Try to insert artist into database and catches exception to
             * show error inside a message box to user. */
            try
            {
                DatabaseHandler.AddArtist(artist);
            }
            catch (Exception error)
            {
                ViewModelsErrorHandler(error);
            }

            // Shows a message boxon success.
            MessageBox.Show("Artist has been successful added to database.",
                "Added artist",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
