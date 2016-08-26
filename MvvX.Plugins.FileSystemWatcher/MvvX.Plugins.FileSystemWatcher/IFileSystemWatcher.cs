using System;
using MvvX.Plugins.FileSystemWatcher.Events;

namespace MvvX.Plugins.FileSystemWatcher
{
    public interface IFileSystemWatcher : IDisposable
    {
        #region events

        /// <summary>
        /// Occurs when a file or directory in the specified Path is changed
        /// </summary>
        event EventHandler<IFileSystemWatcherChanged> Changed;

        /// <summary>
        /// Occurs when a file or directory in the specified Path is created.
        /// </summary>
        event EventHandler<IFileSystemWatcherChanged> Created;

        /// <summary>
        /// Occurs when a file or directory in the specified Path is deleted
        /// </summary>
        event EventHandler<IFileSystemWatcherChanged> Deleted;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the component is enabled
        /// Set this field to true start the watcher
        /// </summary>
        bool EnableRaisingEvents { get; set; }

        /// <summary>
        /// Gets or sets the filter string used to determine what files are monitored in a directory.
        /// Default : "*.*"
        /// </summary>
        string Filter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether subdirectories within the specified path should be monitored.
        /// </summary>
        bool IncludeSubdirectories { get; set; }

        /// <summary>
        /// Gets or sets the path of the directory to watch.
        /// </summary>
        string Path { get; set; }

        #endregion
    }
}
