using System;
using System.IO;
using Android.OS;
using MvvX.Plugins.FileSystemWatcher.Events;

namespace MvvX.Plugins.FileSystemWatcher.Droid.Events
{
    public class PlatformFileSystemWatcherChanged : IFileSystemWatcherChanged
    {
        #region Fields

        private readonly FileObserverEvents fileObserverEvent;
        private readonly string path;

        #endregion

        #region Constructor

        public PlatformFileSystemWatcherChanged(FileObserverEvents fileObserverEvent, string path)
        {
            this.fileObserverEvent = fileObserverEvent;
            this.path = path;
        }

        #endregion

        #region Implements

        public WatcherChangeTypes ChangeType
        {
            get
            {
                switch(fileObserverEvent)
                {
                    case FileObserverEvents.Create:
                        return WatcherChangeTypes.Created;
                    case FileObserverEvents.Delete:
                    case FileObserverEvents.DeleteSelf:
                        return WatcherChangeTypes.Deleted;
                    case FileObserverEvents.Modify:
                    case FileObserverEvents.MovedFrom:
                    case FileObserverEvents.MovedTo:
                    case FileObserverEvents.MoveSelf:
                    case FileObserverEvents.Open:
                    case FileObserverEvents.CloseNowrite:
                    case FileObserverEvents.CloseWrite:
                    case FileObserverEvents.Access:
                    case FileObserverEvents.AllEvents:
                    case FileObserverEvents.Attrib:
                    default:
                        return WatcherChangeTypes.All;
                }
            }
        }

        public string FullPath
        {
            get
            {
                return path;
            }
        }

        public string Name
        {
            get
            {
                return Path.GetFileName(Name);
            }
        }

        #endregion
    }
}
