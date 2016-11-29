using System;
using System.Diagnostics;
using System.IO;
using Android.OS;
using MvvX.Plugins.FileSystemWatcher.Events;
using MvvX.Plugins.FileSystemWatcher.Droid.Events;
using Android.Runtime;

namespace MvvX.Plugins.FileSystemWatcher.Droid
{
    internal class CustomFileObserver : FileObserver
    {
        public event EventHandler<PlatformFileSystemWatcherChanged> EventFired;

        public CustomFileObserver(string path)
            : base(path)
        {

        }

        public override void OnEvent([GeneratedEnum] FileObserverEvents e, string path)
        {
            if(EventFired != null)
            {
                EventFired(this, new PlatformFileSystemWatcherChanged(e, path));
            }
        }
    }

    public class PlatformFileSystemWatcher : IFileSystemWatcher
    {
        #region private fields

        private CustomFileObserver fileSystemWatcher;

        #endregion

        #region Constructor

        public PlatformFileSystemWatcher()
        {
        }

        #endregion

        #region Interface
        
        
        public event EventHandler<IFileSystemWatcherChanged> Changed;

        public event EventHandler<IFileSystemWatcherChanged> Created;

        public event EventHandler<IFileSystemWatcherChanged> Deleted;

        private bool enableRaisingEvents;
        public bool EnableRaisingEvents
        {
            get
            {
                return enableRaisingEvents;
            }

            set
            {
                enableRaisingEvents = value;
                if (enableRaisingEvents)
                {
                    if (this.fileSystemWatcher == null)
                        throw new InvalidOperationException("Please provide a Path before start raising events");

                    this.fileSystemWatcher.StartWatching();
                }
                else
                    this.fileSystemWatcher.StopWatching();
            }
        }

        /// <summary>
        /// TODO : Implement a filter in next release. The filter is not a native functionality of Android
        /// </summary>
        public string Filter { get; set; }

        private string path;
        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
                if (this.fileSystemWatcher == null)
                    this.fileSystemWatcher.Dispose();

                this.fileSystemWatcher = new CustomFileObserver(path);
                fileSystemWatcher.EventFired += FileSystemWatcher_EventFired;
            }
        }

        private void FileSystemWatcher_EventFired(object sender, PlatformFileSystemWatcherChanged e)
        {
            System.Diagnostics.Debug.WriteLine("Changed event fired");
            switch(e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    if (Changed != null)
                    {
                        this.Changed(sender, e);
                    }
                    break;
                case WatcherChangeTypes.Created:
                    if (Created != null)
                    {
                        this.Created(sender, e);
                    }
                    break;
                case WatcherChangeTypes.Deleted:
                    if (Deleted != null)
                    {
                        this.Deleted(sender, e);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private bool includeSubdirectories = false;
        /// <summary>
        /// By design, Android do not manage sub directories.
        /// TODO : Implement a recursive tool that check sub directories.
        /// </summary>
        public bool IncludeSubdirectories
        {
            get
            {
                return includeSubdirectories;
            }
            set
            {
                includeSubdirectories = false;
            }
        }

        public void Dispose()
        {
            this.fileSystemWatcher.EventFired -= FileSystemWatcher_EventFired;
            this.fileSystemWatcher.Dispose();
        }

        #endregion
    }
}
