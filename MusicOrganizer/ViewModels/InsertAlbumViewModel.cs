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
    class InsertAlbumViewModel : NotifyDataErrorInfo<InsertAlbumViewModel>
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public InsertAlbumViewModel()
        {
            InitializesCommands();
            InitializesArtists();
            InitializesValidationRules();
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
                    EnableOrDisableAddAlbumButton();
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
                    EnableOrDisableAddAlbumButton();
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
                    EnableOrDisableAddAlbumButton();
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
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Enables or disables button "Add Album".
        /// </summary>
        public bool CanAddAlbum { get; private set; }

        /// <summary>
        /// Executes InsertAlbumIntoDB if CanExecuteInsertAlbumCommand is true.
        /// </summary>
        public RelayCommand InsertAlbumCommand { private set; get; }

        /// <summary>
        /// Checks for HasErrors. No error sets CanAddAlbum to true.
        /// Errors sets CanAddAlbum to false. This enables or disables the
        /// AddAlbum button.
        /// </summary>
        private void EnableOrDisableAddAlbumButton()
        {
            if (!HasErrors
                &&
                !string.IsNullOrEmpty(AlbumTitle)
                &&
                !string.IsNullOrEmpty(AlbumPicture)
                &&
                AlbumPicture.Length > 10
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
        /// Allows or disables InsertAlbumCommand.
        /// </summary>
        private bool CanExecuteInsertAlbum(object obj = null)
        {
            return CanAddAlbum;
        }

        /// <summary>
        /// Initilizes InsertAlbumCommand.
        /// </summary>
        private void InitializesCommands()
        {

            // Initilizes InsertAlbumCommand.
            InsertAlbumCommand = new RelayCommand(lambda =>
            {
                InsertAlbumIntoDB();
            },
                lambda =>
                {
                    Predicate<object> predicate =
                    new Predicate<object>(CanExecuteInsertAlbum);
                    return predicate(null);
                });
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
                foreach (var artist in DatabaseHandler.ReadArtists().ToArray())
                {
                    artistsNames.Add(artist.Name);
                }
            }
            catch (Exception e)
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
        private void InsertAlbumIntoDB()
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

        /// <summary>
        /// Initializes all validation rules for the textboxes.
        /// </summary>
        private void InitializesValidationRules()
        {
            Rules.Add(new DelegateRule<InsertAlbumViewModel>(
            "AlbumTitle",
            "Title of album cannot be empty.",
            x => !string.IsNullOrEmpty(x.AlbumTitle)));
            Rules.Add(new DelegateRule<InsertAlbumViewModel>(
            "AlbumTitle",
            "Title of album must be at least one character.",
            x => x.AlbumTitle.Length > 0 ? true : false));
            Rules.Add(new DelegateRule<InsertAlbumViewModel>(
            "AlbumPicture",
            "Picture of album cannot be empty.",
            x => !string.IsNullOrEmpty(x.AlbumPicture)));
            Rules.Add(new DelegateRule<InsertAlbumViewModel>(
            "AlbumPicture",
            "Picture of album has to be internet address and is longer than 9",
            x => x.AlbumPicture != null ?
            (x.AlbumPicture.Contains("http://") || 
            x.AlbumPicture.Contains("https://"))
            && x.AlbumPicture.Length > 10
            : false));
            Rules.Add(new DelegateRule<InsertAlbumViewModel>(
            "AlbumCountTracks",
            "This has to be a number.",
            x => int.TryParse(x.AlbumCountTracks, out var result)
            && int.Parse(x.AlbumCountTracks) > 0));
        }
    }
}
