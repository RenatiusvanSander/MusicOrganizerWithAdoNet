using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Presentation logic for UpdateTrackView.
    /// </summary>
    public class UpdateTrackViewModel : ViewModelBase
    {

        /// <summary>
        /// Ctor initializes ComboBoxes for select artists and albums.
        /// </summary>
        public UpdateTrackViewModel()
        {
            InitializesArtists();
            InitializesAlbum();
        }

        /// <summary>
        /// Ctor initializes ComboBoxes for selecting artists and albums and
        /// copy trackToUpdate.track_id in track_id.
        /// </summary>
        /// <param name="trackToUpdate">tracks</param>
        public UpdateTrackViewModel(tracks trackToUpdate)
        {
            InitializesMembers(trackToUpdate);
        }

        /* private varies for the properties */
        private List<string> updateAlbum;
        private List<string> updateArtist;
        private string updateTitle;
        private string updateDuration;
        private string updateAlbumPosition;
        private string updateComposer;
        private string updateDescription;
        private string updateDiscNumber;
        private string updateGenre;
        private string updateLyricist;
        private string updateBPM;
        private string updateFilepath;
        private string updateSelectedArtist;
        private string updateSelectedAlbum;
        private tracks currentTrackToUpdate;

        // Store and updates belonging album of track.
        public List<string> UpdateAlbum
        {
            get
            {
                return updateAlbum;
            }
            set
            {
                if (updateAlbum == null
                    ||
                    updateAlbum != value)
                {
                    updateAlbum = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates select6ed album of track.
        public string UpdateSelectedAlbum
        {
            get
            {
                return updateSelectedAlbum;
            }
            set
            {
                if (string.IsNullOrEmpty(updateSelectedAlbum)
                    ||
                    !updateSelectedAlbum.Equals(value))
                {
                    updateSelectedAlbum = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates list of artists.
        public List<string> UpdateArtist
        {
            get
            {
                return updateArtist;
            }
            set
            {
                if (updateArtist == null
                    ||
                    !updateArtist.Equals(value))
                {
                    updateArtist = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates selected artist.
        public string UpdateSelectedArtist
        {
            get
            {
                return updateSelectedArtist;
            }
            set
            {
                if (string.IsNullOrEmpty(updateSelectedArtist)
                    ||
                    !updateSelectedArtist.Equals(value))
                {
                    updateSelectedArtist = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates title of track.
        public string UpdateTitle
        {
            get
            {
                return updateTitle;
            }
            set
            {
                if (string.IsNullOrEmpty(updateTitle)
                    ||
                    !updateTitle.Equals(value))
                {
                    updateTitle = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates duration of a track.
        public string UpdateDuration
        {
            get
            {
                return updateDuration;
            }
            set
            {
                if (string.IsNullOrEmpty(updateDuration)
                    ||
                    !updateDuration.Equals(value))
                {
                    updateDuration = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates track position of album.
        public string UpdateAlbumPosition
        {
            get
            {
                return updateAlbumPosition;
            }
            set
            {
                if (string.IsNullOrEmpty(updateAlbumPosition)
                    ||
                    !updateAlbumPosition.Equals(value))
                {
                    updateAlbumPosition = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates composer of track.
        public string UpdateComposer
        {
            get
            {
                return updateComposer;
            }
            set
            {
                if (string.IsNullOrEmpty(updateComposer)
                    ||
                    !updateComposer.Equals(value))
                {
                    updateComposer = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates description of track.
        public string UpdateDescription
        {
            get
            {
                return updateDescription;
            }
            set
            {
                if (string.IsNullOrEmpty(updateDescription)
                    ||
                    !updateDescription.Equals(value))
                {
                    updateDescription = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates disc number of track.
        public string UpdateDiscNumber
        {
            get
            {
                return updateDiscNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(updateDiscNumber)
                    ||
                    !updateDiscNumber.Equals(value))
                {
                    updateDiscNumber = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates genre of a track.
        public string UpdateGenre
        {
            get
            {
                return updateGenre;
            }
            set
            {
                if (string.IsNullOrEmpty(updateGenre)
                    ||
                    !updateGenre.Equals(value))
                {
                    updateGenre = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates song writer.
        public string UpdateLyricist
        {
            get
            {
                return updateLyricist;
            }
            set
            {
                if (string.IsNullOrEmpty(updateLyricist)
                    ||
                    !updateLyricist.Equals(value))
                {
                    updateLyricist = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Stores and updates bpm of track.
        public string UpdateBPM
        {
            get
            {
                return updateBPM;
            }
            set
            {
                if (string.IsNullOrEmpty(updateBPM)
                    ||
                    !updateBPM.Equals(value))
                {
                    updateBPM = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Store and updates filepath of track.
        public string UpdateFilepath
        {
            get
            {
                return updateFilepath;
            }
            set
            {
                if (string.IsNullOrEmpty(updateFilepath)
                    ||
                    !updateFilepath.Equals(value))
                {
                    updateFilepath = value;
                    CheckAndAllowUpdateTrackIntoDB();
                    OnPropertyChanged();
                }
            }
        }

        // Enables or disables add track button on InsertTrackView.
        public bool CanUpdateTrack { get; private set; }

        /// <summary>
        /// Enables or disables the "Add Album" button on InsertTrackView.
        /// </summary>
        private void CheckAndAllowUpdateTrackIntoDB()
        {

            // Enables if all properties are not null.
            if (!string.IsNullOrEmpty(UpdateSelectedAlbum)
                &&
                !string.IsNullOrEmpty(UpdateSelectedArtist)
                &&
                !string.IsNullOrEmpty(UpdateTitle)
                &&
                !string.IsNullOrEmpty(UpdateDuration)
                &&
                !string.IsNullOrEmpty(UpdateAlbumPosition)
                &&
                !string.IsNullOrEmpty(UpdateComposer)
                &&
                !string.IsNullOrEmpty(UpdateDescription)
                &&
                !string.IsNullOrEmpty(UpdateDiscNumber)
                &&
                !string.IsNullOrEmpty(UpdateGenre)
                &&
                !string.IsNullOrEmpty(UpdateLyricist)
                &&
                !string.IsNullOrEmpty(UpdateBPM)
                &&
                !string.IsNullOrEmpty(UpdateFilepath))
            {
                CanUpdateTrack = true;
            }
            else
            {
                CanUpdateTrack = false;
            }

            // Updates property CanAddTrack.
            OnPropertyChanged(nameof(CanUpdateTrack));
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
            UpdateArtist = artistsNames;
            UpdateSelectedArtist = currentTrackToUpdate.artists.Name;
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
            UpdateAlbum = albumsNames;
            UpdateSelectedAlbum = currentTrackToUpdate.albums.title;
        }

        /// <summary>
        /// Updas a track in database or throws an exception to inform user.
        /// </summary>
        public void UpdateTrackIntoDB()
        {

            // Tries to update track into database.
            try
            {
                DatabaseHandler.UpdateTrack(currentTrackToUpdate.track_id,
                    UpdateSelectedAlbum,
                    UpdateSelectedArtist,
                    UpdateTitle,
                    UpdateDuration,
                    UpdateAlbumPosition,
                    UpdateComposer,
                    UpdateDescription,
                    UpdateDiscNumber,
                    UpdateGenre,
                    UpdateLyricist,
                    UpdateBPM,
                    UpdateFilepath);

                MessageBox.Show("Track has been successful updated.");
            }
            catch (Exception e)
            {
                ViewModelsErrorHandler(e);
            }
        }

        /// <summary>
        /// Initializes all values of members.
        /// </summary>
        /// <param name="trackToUpdate">tracks</param>
        private void InitializesMembers(tracks trackToUpdate)
        {
            currentTrackToUpdate = trackToUpdate;
            InitializesArtists();
            InitializesAlbum();

            // Copy values into properties.
            UpdateAlbumPosition = trackToUpdate.album_position.ToString();
            UpdateBPM = trackToUpdate.bpm.ToString();
            UpdateComposer = trackToUpdate.composer;
            UpdateDescription = trackToUpdate.description;
            UpdateDuration = trackToUpdate.duration.ToString();
            UpdateFilepath = trackToUpdate.filepath;
            UpdateGenre = trackToUpdate.genre;
            UpdateLyricist = trackToUpdate.lyricist;
            UpdateTitle = trackToUpdate.track_title;
            UpdateDiscNumber = trackToUpdate.disc_number.ToString();
        }
    }
}
