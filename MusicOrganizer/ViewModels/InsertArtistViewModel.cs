using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for InsertArtistView.
    /// </summary>
    public class InsertArtistViewModel : NotifyDataErrorInfo<InsertArtistViewModel>
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public InsertArtistViewModel()
        {
            InitializesValidationRules();
            InsertArtistCommand = new RelayCommand(lambda => InsertArtistIntoDB(),
                lambda =>
                {
                    var artistExists = DatabaseHandler.ArtistExist(ArtistName);

                    /* Artist exists and HasErrors is true, disbales to insert an
                    artist to database. User is informed via MessageBox */

                    if (artistExists == true && HasErrors == true)
                    {
                        MessageBox.Show($"This {ArtistName} exists.",
                            "Artist exists",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return false;
                    }

                    // Artist is inexisting and enables to insert artist into database.
                    return !DatabaseHandler.ArtistExist(ArtistName);
                });
        }

        /*
        /// <summary>
        /// Checks if artist exists and Transceives a bool for
        /// InsertArtistCommand. If artist not exists this method returns true.
        /// An artist has to be none duplicate in database. 
        /// </summary>
        /// <returns>Returns true, means artist is inexisting in database.
        /// False means artist is already in database stored.</returns>
        private bool CanExecuteInsertArtistCommand()
        {
            var artistExists = DatabaseHandler.ArtistExist(ArtistName);

            /* Artist exists and HasErrors is true, disbales to insert an
            artist to database. User is informed via MessageBox */
        /*
        if (artistExists == true  && HasErrors == true)
        {
            MessageBox.Show($"This {ArtistName} exists.",
                "Artist exists",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return false;
        }

        // Artist is inexisting and enables to insert artist into database.
        return !DatabaseHandler.ArtistExist(ArtistName);
    }*/

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

        /// <summary>
        /// 
        /// </summary>
        public RelayCommand InsertArtistCommand { private set; get; }

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
            CanInsertArtistIntoDB = !HasErrors ? true : false;

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

        /// <summary>
        /// Initializes validation rules for all properties.
        /// </summary>
        private void InitializesValidationRules()
        {
            Rules.Add(new DelegateRule<InsertArtistViewModel>(
            "ArtistName",
            "Artist's name cannot be empty.",
            x => !string.IsNullOrEmpty(x.ArtistName)));
            Rules.Add(new DelegateRule<InsertArtistViewModel>(
                 "ArtistHistory",
                 "Artist's history cannot be empty.",
                 x => !string.IsNullOrEmpty(x.ArtistHistory)));
            Rules.Add(new DelegateRule<InsertArtistViewModel>(
            "ArtistPicture",
            "Artist's picture cannot be empty.",
            x => !string.IsNullOrEmpty(x.ArtistPicture)));
            Rules.Add(new DelegateRule<InsertArtistViewModel>(
            "ArtistPicture",
            "Artist's picture has to be an internet address.",
            x => x.ArtistPicture != null ? x.ArtistPicture.Contains("http://")
            || x.ArtistPicture.Contains("https://")
            : false));
            Rules.Add(new DelegateRule<InsertArtistViewModel>(
            "ArtistWebsite",
            "Artist's website cannot be empty.",
            x => !string.IsNullOrEmpty(x.ArtistWebsite)));
            Rules.Add(new DelegateRule<InsertArtistViewModel>(
            "ArtistWebsite",
            "Artist's website has to be an internet address.",
            x => x.ArtistWebsite != null ? x.ArtistWebsite.Contains("http://")
            || x.ArtistWebsite.Contains("https://")
            : false));
        }
    }
}
