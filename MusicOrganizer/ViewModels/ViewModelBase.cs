using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// This implements the logic for INotifyPropertyChanged interface and is
    /// used for every ViewModel to update data to the views.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        /// <summary>
        /// EventHandler for a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises event PropertyChanged for every ViewModel.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
