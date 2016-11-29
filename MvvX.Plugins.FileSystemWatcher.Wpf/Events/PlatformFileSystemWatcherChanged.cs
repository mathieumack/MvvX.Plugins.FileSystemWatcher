using System;
using System.IO;
using MvvX.Plugins.FileSystemWatcher.Events;

namespace MvvX.Plugins.FileSystemWatcher.Wpf.Events
{
    public class PlatformFileSystemWatcherChanged : IFileSystemWatcherChanged
    {
        #region Fields

        private readonly FileSystemEventArgs fileSystemEventArgs;

        #endregion

        #region Constructor

        public PlatformFileSystemWatcherChanged(FileSystemEventArgs fileSystemEventArgs)
        {
            this.fileSystemEventArgs = fileSystemEventArgs;
        }

        #endregion

        #region Implements

        public WatcherChangeTypes ChangeType
        {
            get
            {
                return (WatcherChangeTypes)(int)fileSystemEventArgs.ChangeType;
            }
        }

        public string FullPath
        {
            get
            {
                return fileSystemEventArgs.FullPath;
            }
        }

        public string Name
        {
            get
            {
                return fileSystemEventArgs.Name;
            }
        }

        #endregion
    }
}
