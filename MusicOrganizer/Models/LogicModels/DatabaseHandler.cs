using MusicOrganizer.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicOrganizer.Models.LogicModels
{

    /// <summary>
    /// DatabaseHandler does all logic to change, get, insert and update
    /// tables on database.
    /// </summary>
    public class DatabaseHandler
    {

        // Connects programs via OR-Mapper to MySQL database.
        private static MusicDBEntityDataModel musicDBModel;

        /// <summary>
        /// Ctor.
        /// </summary>
        private DatabaseHandler()
        {
        }

        /// <summary>
        /// Reads all albums from database and returns this to ViewModel.
        /// </summary>
        /// <returns>List<albums></returns>
        public static List<albums> ReadAlbums()
        {
            musicDBModel = new MusicDBEntityDataModel();
            List<albums> albumsList = new List<albums>();

            /* Try to get a list of albums from database */
            try
            {
                albumsList = musicDBModel.albums.ToList();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }

            return albumsList;
        }

        /// <summary>
        /// Reads all tracks of an album and returns them as a list.
        /// </summary>
        /// <param name="album_id">decimal</param>
        /// <returns></returns>
        public static List<tracks> ReadAlbumTracks(decimal album_id)
        {
            List<tracks> albumTrackList = new List<tracks>();

            // Tries to read all tracks of album and fills albumTrackList.
            try
            {
                albumTrackList = musicDBModel.tracks
                    .Where(albumTracks => albumTracks.album_id == album_id)
                    .ToList();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }

            return albumTrackList;
        }

        /// <summary>
        /// Deletes an album from database.
        /// </summary>
        /// <param name="currentItem"></param>
        public static void DeleteAlbumAndTracks(albums currentItem)
        {

            // Tries to delete tracks and album from database.
            try
            {
                musicDBModel.tracks.RemoveRange(currentItem.tracks);
                musicDBModel.albums.Remove(currentItem);

                musicDBModel.SaveChanges();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }
        }

        /// <summary>
        /// Adds artist into database or throws exception if this is
        /// unsuccessful.
        /// </summary>
        /// <param name="artist">artists</param>
        public static void AddArtist(artists artist)
        {

            // Try to save artist object into database.
            try
            {
                musicDBModel.artists.Add(artist);
            }
            catch (Exception e)
            {
                ThrowException(e);
            }

            musicDBModel.SaveChanges();

            // Activates event DatabaseUpdated.
            OnDatabaseUpdated(new EventArgs());
        }

        /// <summary>
        /// Gets a user-defined artist from database.
        /// </summary>
        /// <param name="artist">artists</param>
        /// <returns>artists</returns>
        public static artists GetArtist(artists artist)
        {
            artists artistFromDatabase = null;

            // Refactor to EF Query
            try
            {
                artistFromDatabase = musicDBModel.artists.Find(artist);
            }
            catch (Exception e)
            {
                ThrowException(e);
            }

            return artistFromDatabase;
        }

        /// <summary>
        /// Checks if an artist exists and return true for exist.
        /// </summary>
        /// <param name="artistName">Artist's name as string.</param>
        /// <returns>Returns true for artist exists in database, else it is
        /// false.</returns>
        public static bool ArtistExist(string artistName)
        {

            // Tries to get artist and return true, because artist is not existent in database.
            try
            {
                var artistFromDatabase = musicDBModel.artists
                    .Where(x => x.Name == artistName)
                    .Single();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Throws inner connection error inside an exception.
        /// </summary>
        /// <param name="exception"></param>
        private static void ThrowException(Exception exception)
        {
            throw new Exception("MySQL connection aborted. Please check" +
                    " connectivity and mysql service.", exception);
        }

        /// <summary>
        /// Updates an artist inside database.
        /// </summary>
        /// <param name="artist_id">decimal</param>
        /// <param name="name">string</param>
        /// <param name="history">string</param>
        /// <param name="picture">string</param>
        /// <param name="website">string</param>
        public static void UpdateArtist(decimal artist_id,
            string name,
            string history,
            string picture,
            string website)
        {

            // Tries to update artist into database.
            try
            {

                // Gets artist by artist_id.
                var artist = musicDBModel.artists
                    .Where(entry => entry.artist_id == artist_id)
                    .Single();

                // Updates values ogf an artist.
                artist.History = history;
                artist.Name = name;
                artist.Picture = picture;
                artist.Website = website;

                // Saves changes into database.
                musicDBModel.SaveChanges();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }
        }

        /// <summary>
        /// Adds an album into Database.
        /// </summary>
        /// <param name="albumArtist">string</param>
        /// <param name="albumTitle">string</param>
        /// <param name="albumPicture">string</param>
        /// <param name="albumCountTracks">string</param>
        public static void AddAlbum(string albumArtist,
            string albumTitle,
            string albumPicture,
            string albumCountTracks)
        {

            // Tries to get artist and store new album into database.
            try
            {

                // Gets artist.
                var artist = musicDBModel.artists.
                                Where(a => a.Name == albumArtist)
                                .SingleOrDefault();

                var newAlbum = new albums()
                {
                    artists = artist,
                    Picture = albumPicture,
                    title = albumTitle,
                    TrackCount = albumCountTracks
                };

                // Adds and saves changes to database.
                musicDBModel.albums.Add(newAlbum);
                musicDBModel.SaveChanges();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }

            // Activates event DatabaseUpdated.
            OnDatabaseUpdated(new EventArgs());
        }

        /// <summary>
        /// Reads and returns all artists from database.
        /// </summary>
        /// <returns>List<albums></returns>
        public static List<artists> ReadArtists()
        {
            List<artists> artistsList = new List<artists>();

            /* Try to get a list of artists from database */
            try
            {
                artistsList = musicDBModel.artists.ToList();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }

            return artistsList;
        }

        /// <summary>
        /// Updates album entry in database.
        /// </summary>
        /// <param name="updateTitle"></param>
        /// <param name="updatePicture"></param>
        /// <param name="updateCountTracks"></param>
        public static void UpdateAlbum(decimal id,
            string updateTitle,
            string updatePicture,
            string updateCountTracks)
        {

            // Tries update a specific row of album.
            try
            {

                // Queries albums row via id.
                albums album = musicDBModel.albums
                    .Where(a => a.album_id == id)
                    .Single();

                // Updates values of row.
                album.title = updateTitle;
                album.Picture = updatePicture;
                album.TrackCount = updateCountTracks;

                // Saves and updates Views
                musicDBModel.SaveChanges();
                OnDatabaseUpdated(new EventArgs());
            }
            catch (Exception e)
            {
                ThrowException(e);
            }
        }

        #region eventhandler databaseupdated
        public static event EventHandler DatabaseUpdated;

        /// <summary>
        /// Database update raises DatabaseUpdated.
        /// </summary>
        protected static void OnDatabaseUpdated(EventArgs e)
        {
            EventHandler handler = DatabaseUpdated;
            handler?.Invoke(handler, e);
        }

        /// <summary>
        /// Adds a track into database.
        /// </summary>
        /// <param name="trackSelectedAlbum">string</param>
        /// <param name="trackSelectedArtist">string</param>
        /// <param name="trackTitle">stringparam>
        /// <param name="trackDuration">string</param>
        /// <param name="trackAlbumPosition">string</param>
        /// <param name="trackComposer">string</param>
        /// <param name="trackDescription">string</param>
        /// <param name="trackDiscNumber">string</param>
        /// <param name="trackGenre">string</param>
        /// <param name="trackLyricist">string</param>
        /// <param name="trackBPM">string</param>
        /// <param name="trackFilepath">string</param>
        public static void AddTrack(string trackSelectedAlbum,
            string trackSelectedArtist,
            string trackTitle,
            string trackDuration,
            string trackAlbumPosition,
            string trackComposer,
            string trackDescription,
            string trackDiscNumber,
            string trackGenre,
            string trackLyricist,
            string trackBPM,
            string trackFilepath)
        {

            // Tries to add a track into database or throws an exception.
            try
            {
                // Gets artist.
                var artist = musicDBModel.artists.
                                Where(a => a.Name == trackSelectedArtist)
                                .Single();

                // Gets album.
                var album = musicDBModel.albums.
                                Where(a => a.title == trackSelectedAlbum)
                                .Single();

                tracks track = new tracks()
                {
                    album_id = album.album_id,
                    artist_id = artist.artist_id,
                    track_title = trackTitle,
                    duration = TimeSpan.Parse(trackDuration),
                    album_position = int.Parse(trackAlbumPosition),
                    composer = trackComposer,
                    description = trackDescription,
                    disc_number = int.Parse(trackDiscNumber),
                    genre = trackGenre,
                    lyricist = trackLyricist,
                    bpm = int.Parse(trackBPM),
                    filepath = trackFilepath
                };
                musicDBModel.tracks.Add(track);

                // Saves and updates Views
                musicDBModel.SaveChanges();
                OnDatabaseUpdated(new EventArgs());
            }
            catch (Exception e)
            {
                ThrowException(e);
            }
        }

        /// <summary>
        /// Updates a track in database.
        /// </summary>
        /// <param name="updateSelectedAlbum">string</param>
        /// <param name="updateSelectedArtist">string</param>
        /// <param name="updateTitle">string</param>
        /// <param name="updateDuration">string</param>
        /// <param name="updateAlbumPosition">string</param>
        /// <param name="updateComposer">string</param>
        /// <param name="updateDescription">string</param>
        /// <param name="updateDiscNumber">string</param>
        /// <param name="updateGenre">string</param>
        /// <param name="updateLyricist">string</param>
        /// <param name="updateBPM">string</param>
        /// <param name="updateFilepath">string</param>
        public static void UpdateTrack(decimal track_id,
            string updateSelectedAlbum,
            string updateSelectedArtist,
            string updateTitle,
            string updateDuration,
            string updateAlbumPosition,
            string updateComposer,
            string updateDescription,
            string updateDiscNumber,
            string updateGenre,
            string updateLyricist,
            string updateBPM,
            string updateFilepath)
        {

            // Tries to update track in database.
            try
            {

                // Gets track from database to update.
                var artist = musicDBModel.artists
                    .Where(t => t.Name == updateSelectedArtist)
                    .Single();

                // Gets track from database to update.
                var album = musicDBModel.albums
                    .Where(t => t.title == updateSelectedAlbum
                    &&
                    t.artists.Name == updateSelectedArtist)
                    .Single();

                // Gets track from database to update.
                var track = musicDBModel.tracks
                    .Where(t => t.track_id == track_id)
                    .Single();

                // Updates values of track.
                track.track_id = album.album_id;
                track.album_position = int.Parse(updateAlbumPosition);
                track.artist_id = artist.artist_id;
                track.bpm = int.Parse(updateBPM);
                track.composer = updateComposer;
                track.description = updateDescription;
                track.disc_number = int.Parse(updateDiscNumber);
                track.duration = TimeSpan.Parse(updateDuration);
                track.filepath = updateFilepath;
                track.genre = updateGenre;
                track.lyricist = updateLyricist;
                track.track_title = updateTitle;

                // Saves changes.
                musicDBModel.SaveChanges();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }
        }

        /// <summary>
        /// Checks for a duplicate in positioning.
        /// </summary>
        /// <param name="trackAlbumPosition">Position on tracklist of album as
        /// string number.</param>
        /// <param name="trackSelectedArtist">Selected artist from user as
        /// string.</param>
        /// <param name="trackSelectedAlbum">Selected album from user as string.</param>
        /// <returns>Returns true then there is not any duplicate. False means
        /// there are duplicates.</returns>
        public static bool TrackAlbumPositionIsNoDuplicate(
            string trackAlbumPosition,
            string trackSelectedArtist,
            string trackSelectedAlbum)
        {

            /* Tries to get a track containing the free parameters from method
             * parameters list.
             */
            try
            {
                var track = musicDBModel.tracks
                    .Where(t => t.album_position == int
                    .Parse(trackAlbumPosition)
                    &&
                    t.artists.Name == trackSelectedArtist
                    &&
                    t.albums.title == trackSelectedAlbum)
                    .Single();
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
