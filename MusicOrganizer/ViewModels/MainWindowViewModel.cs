using MusicOrganizer.Models.LogicModels;
using MusicOrganizer.Models.Services;
using System;
using System.Collections.Generic;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// 
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        public MainWindowViewModel()
        {
            Albums = DatabaseHandler.ReadAlbums();
        }

        private List<albums> albums;

        /// <summary>
        /// 
        /// </summary>
        public List<albums> Albums {
            get
            {
                return albums;
            }
            private set
            {
                if(albums != value)
                {
                    albums = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
