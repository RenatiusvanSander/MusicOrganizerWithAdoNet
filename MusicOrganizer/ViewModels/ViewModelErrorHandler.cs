using System;
using System.Windows;

namespace MusicOrganizer.ViewModels
{

    /// <summary>
    /// Adds a method ViewModelsErrorHandler to a ViewModel. The method outputs
    /// a MessageBox, which informs user about the thrown exception.
    /// </summary>
    public abstract class ViewModelErrorHandler
    {

        #region errorhandler

        /// <summary>
        /// Handles every error inside a ViewModel.
        /// </summary>
        /// <param name="error">Exception</param>
        public void ViewModelsErrorHandler(Exception error)
        {
            MessageBox.Show($"{error.Message} {error.InnerException}",
                "Connection error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        #endregion
    }
}
