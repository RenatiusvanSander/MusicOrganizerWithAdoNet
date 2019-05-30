﻿using MusicOrganizer.Models.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicOrganizer.Models.LogicModels
{

    /// <summary>
    /// DatabaseHandler does all logic to change, get, insert and update
    /// tables on database.
    /// </summary>
    public class DatabaseHandler
    {

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
        /// Throws inner connection error inside an exception.
        /// </summary>
        /// <param name="exception"></param>
        private static void ThrowException(Exception exception)
        {
            throw new Exception("MySQL connection aborted. Please check" +
                    " connectivity and mysql service.", exception);
        }

        /// <summary>
        /// 
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
            artists artist;
            albums newAlbum;

            // Try to get artist and store new album into database.
            try
            {
                artist = musicDBModel.artists.
                                Where(a => a.Name == albumArtist)
                                .SingleOrDefault();

                newAlbum = new albums()
                {
                    artists = artist,
                    Picture = albumPicture,
                    title = albumTitle,
                    TrackCount = albumCountTracks
                };
                musicDBModel.albums.Add(newAlbum);

                musicDBModel.SaveChanges();
            }
            catch (Exception e)
            {
                ThrowException(e);
            }
        }

        // Refactor to use for every where and different queries.
        private static DbSet GetDbSetObject()
        {
            return null;
        }
    }
}
