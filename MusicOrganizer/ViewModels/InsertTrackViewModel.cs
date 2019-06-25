﻿using MusicOrganizer.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for InsertTrackView.
    /// </summary>
    public class InsertTrackViewModel : NotifyDataErrorInfo<InsertTrackViewModel>
    {

        /// <summary>
        /// Ctor initializes properties for the ComboBoxes, Artist and Album,
        /// on InsertTrackView.
        /// </summary>
        public InsertTrackViewModel()
        {
            InitializesCommands();
            InitializesArtists();
            InitializesAlbum();
            InitializesValidationRules();
        }

        /* private varies for the properties */
        private List<string> trackAlbum;
        private List<string> trackArtist;
        private string trackTitle;
        private string trackDuration;
        private string trackAlbumPosition;
        private string trackComposer;
        private string trackDescription;
        private string trackDiscNumber;
        private string trackGenre;
        private string trackLyricist;
        private string trackBPM;
        private string trackFilepath;
        private string trackSelectedArtist;
        private string trackSelectedAlbum;

        /// <summary>
        /// Databinding for insert a track into database.
        /// Initiated via button add track.
        /// </summary>
        public RelayCommand InsertTrackCommand { private set; get; }

        // Store and updates belonging album of track.
        public List<string> TrackAlbum
        {
            get
            {
                return trackAlbum;
            }
            set
            {
                if (trackAlbum == null
                    ||
                    trackAlbum != value)
                {
                    trackAlbum = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates select6ed album of track.
        public string TrackSelectedAlbum
        {
            get
            {
                return trackSelectedAlbum;
            }
            set
            {
                if (string.IsNullOrEmpty(trackSelectedAlbum)
                    ||
                    !trackSelectedAlbum.Equals(value))
                {
                    trackSelectedAlbum = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates list of artists.
        public List<string> TrackArtist
        {
            get
            {
                return trackArtist;
            }
            set
            {
                if (trackArtist == null
                    ||
                    !trackArtist.Equals(value))
                {
                    trackArtist = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates selected artist.
        public string TrackSelectedArtist
        {
            get
            {
                return trackSelectedArtist;
            }
            set
            {
                if (string.IsNullOrEmpty(trackSelectedArtist)
                    ||
                    !trackSelectedArtist.Equals(value))
                {
                    trackSelectedArtist = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates title of track.
        public string TrackTitle
        {
            get
            {
                return trackTitle;
            }
            set
            {
                if (string.IsNullOrEmpty(trackTitle)
                    ||
                    !trackTitle.Equals(value))
                {
                    trackTitle = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates duration of a track.
        public string TrackDuration
        {
            get
            {
                return trackDuration;
            }
            set
            {
                if (string.IsNullOrEmpty(trackDuration)
                    ||
                    !trackDuration.Equals(value))
                {
                    trackDuration = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates track position of album.
        public string TrackAlbumPosition
        {
            get
            {
                return trackAlbumPosition;
            }
            set
            {
                if (string.IsNullOrEmpty(trackAlbumPosition)
                    ||
                    !trackAlbumPosition.Equals(value))
                {
                    trackAlbumPosition = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates composer of track.
        public string TrackComposer
        {
            get
            {
                return trackComposer;
            }
            set
            {
                if (string.IsNullOrEmpty(trackComposer)
                    ||
                    !trackComposer.Equals(value))
                {
                    trackComposer = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates description of track.
        public string TrackDescription
        {
            get
            {
                return trackDescription;
            }
            set
            {
                if (string.IsNullOrEmpty(trackDescription)
                    ||
                    !trackDescription.Equals(value))
                {
                    trackDescription = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates disc number of track.
        public string TrackDiscNumber
        {
            get
            {
                return trackDiscNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(trackDiscNumber)
                    ||
                    !trackDiscNumber.Equals(value))
                {
                    trackDiscNumber = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates genre of a track.
        public string TrackGenre
        {
            get
            {
                return trackGenre;
            }
            set
            {
                if (string.IsNullOrEmpty(trackGenre)
                    ||
                    !trackGenre.Equals(value))
                {
                    trackGenre = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates song writer.
        public string TrackLyricist
        {
            get
            {
                return trackLyricist;
            }
            set
            {
                if (string.IsNullOrEmpty(trackLyricist)
                    ||
                    !trackLyricist.Equals(value))
                {
                    trackLyricist = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates bpm of track.
        public string TrackBPM
        {
            get
            {
                return trackBPM;
            }
            set
            {
                if (string.IsNullOrEmpty(trackBPM)
                    ||
                    !trackBPM.Equals(value))
                {
                    trackBPM = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Store and updates filepath of track.
        public string TrackFilepath
        {
            get
            {
                return trackFilepath;
            }
            set
            {
                if (string.IsNullOrEmpty(trackFilepath)
                    ||
                    !trackFilepath.Equals(value))
                {
                    trackFilepath = value;
                    CheckAndAllowInsertTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Enables or disables add track button on InsertTrackView.
        public bool CanAddTrack { get; private set; }

        /// <summary>
        /// Enables or disables the "Add Album" button on InsertTrackView.
        /// </summary>
        private void CheckAndAllowInsertTrackIntoDB()
        {

            // Enables if all properties are not null.
            if (!HasErrors)
            {
                CanAddTrack = true;
            }
            else
            {
                CanAddTrack = false;
            }

            // Updates property CanAddTrack.
            OnPropertyChanged(nameof(CanAddTrack));
        }

        /// <summary>
        /// Allows execution of InsertTrackCommand RelayCommand object.
        /// </summary>
        /// <param name="obj">object is implemented to satisfy ICommand
        /// interface implementation. It is set to null by parameters list
        /// of CanExecuteInsertTrackCommand</param>
        /// <returns></returns>
        private bool CanExecuteInsertTrackCommand(object obj = null)
        {

            // Enables CanExecute.
            if (CanAddTrack
                &&
                !string.IsNullOrEmpty(TrackSelectedAlbum)
                &&
                !string.IsNullOrEmpty(TrackSelectedArtist)
                &&
                !string.IsNullOrEmpty(TrackTitle)
                &&
                !string.IsNullOrEmpty(TrackDuration)
                &&
                !string.IsNullOrEmpty(TrackAlbumPosition)
                &&
                !string.IsNullOrEmpty(TrackComposer)
                &&
                !string.IsNullOrEmpty(TrackDescription)
                &&
                !string.IsNullOrEmpty(TrackDiscNumber)
                &&
                !string.IsNullOrEmpty(TrackGenre)
                &&
                !string.IsNullOrEmpty(TrackLyricist)
                &&
                !string.IsNullOrEmpty(TrackBPM)
                &&
                !string.IsNullOrEmpty(TrackFilepath))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inserts track into database or informs user about an error message.
        /// </summary>
        private void InsertTrackIntoDB()
        {

            // Tries to add track into database.
            try
            {
                DatabaseHandler.AddTrack(TrackSelectedAlbum,
                TrackSelectedArtist,
                TrackTitle,
                TrackDuration,
                TrackAlbumPosition,
                TrackComposer,
                TrackDescription,
                TrackDiscNumber,
                TrackGenre,
                TrackLyricist,
                TrackBPM,
                TrackFilepath);

                // Informs user track is added.
                MessageBox.Show("Track has been successful added to album.",
                    "Track added",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                ViewModelsErrorHandler(e);
            }
        }

        /// <summary>
        /// Initializes all Commands, which are type of RelayCommand.
        /// </summary>
        private void InitializesCommands()
        {
            InsertTrackCommand = new RelayCommand(lambda =>
            {
                InsertTrackIntoDB();
            },
                lambda =>
                {
                    Predicate<object> predicate =
                    new Predicate<object>(CanExecuteInsertTrackCommand);
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
            TrackArtist = artistsNames;
            TrackSelectedArtist = artistsNames.ToArray()[0];
        }

        /// <summary>
        /// Initializes albums property for the combobox.
        /// </summary>
        private void InitializesAlbum()
        {
            List<string> albumsNames = new List<string>();

            // Tries to fill artistsNames. Or throw an error.
            try
            {
                foreach (var album in DatabaseHandler.ReadAlbums().ToArray())
                {
                    albumsNames.Add(album.title);
                }
            }
            catch (Exception e)
            {
                ViewModelsErrorHandler(e);
            }

            // Copy values.
            TrackAlbum = albumsNames;
            TrackSelectedAlbum = albumsNames.ToArray()[0];
        }

        /// <summary>
        /// Initializes validation rules in InsertTrackViewModel object
        /// </summary>
        private void InitializesValidationRules()
        {
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
            "TrackTitle",
            "Title of track cannot be empty.",
            x => !string.IsNullOrEmpty(x.TrackTitle)));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
            "TrackTitle",
            "Title of track cannothas to be two characters minimum.",
            x => x.TrackTitle.Length > 1));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
            "TrackDuration",
            "Duration has to contain minutes and seconds separated by :.",
            x => !string.IsNullOrEmpty(x.TrackDuration) ?
            TimeSpan.TryParse(x.TrackDuration, out var result) : false));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
           "TrackAlbumPosition",
           "Position of track cannot be duplicated and has to be a number.",
           x => !string.IsNullOrEmpty(x.TrackAlbumPosition) && int
           .TryParse(x.TrackAlbumPosition, out var result) ?
           DatabaseHandler.TrackAlbumPositionIsNoDuplicate(
               x.TrackAlbumPosition,
               x.TrackSelectedArtist,
               x.TrackSelectedAlbum)
               : false));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
           "TrackComposer",
           "Composer cannot be empty.",
           x => !string.IsNullOrEmpty(x.TrackComposer)
           &&
           x.TrackComposer.Length > 1));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackDescription",
                "Description cannot be empty.",
                x => !string.IsNullOrEmpty(x.TrackDescription)));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackDiscNumber",
                "Number of disc has to be an integer.",
                x => !string.IsNullOrEmpty(TrackDiscNumber) ?
                int.TryParse(x.TrackDiscNumber, out var result)
                &&
                int.Parse(x.TrackDiscNumber) > 0 : false));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackGenre",
                "Genre of track cannot be empty.",
                x => !string.IsNullOrEmpty(x.TrackGenre)
                ||
                x.TrackGenre.Length > 2));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackLyricist",
                "Lyricist cannot be empty.",
                x => !string.IsNullOrEmpty(x.TrackLyricist)));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackBPM",
                "BPM has to be point or complete number.",
                x => int.TryParse(x.TrackBPM, out var result)
                ||
                double.TryParse(x.TrackBPM, out var result2)));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackBPM",
                "BPM has to be greater than 0.",
                x => !string.IsNullOrEmpty(TrackBPM) ?
                int.Parse(x.TrackBPM) > 0 || double.Parse(x.TrackBPM) > 0.1
                : false));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackFilepath",
                "File path cannot be empty.",
                x => !string.IsNullOrEmpty(x.TrackFilepath)));
            Rules.Add(new DelegateRule<InsertTrackViewModel>(
                "TrackFilepath",
                "File path has to exist.",
                x => !string.IsNullOrEmpty(TrackFilepath) ?
                File.Exists(x.TrackFilepath) : false));
        }
    }
}
