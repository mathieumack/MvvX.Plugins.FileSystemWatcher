//using System;
//using System.Diagnostics;
//using System.IO;
//using MvvX.Plugins.FileSystemWatcher.Events;
//using MvvX.Plugins.FileSystemWatcher.Touch.Events;

//namespace MvvX.Plugins.FileSystemWatcher.Touch
//{
//    public class PlatformFileSystemWatcher : IFileSystemWatcher
//    {
//        #region private fields

//        private readonly System.IO.FileSystemWatcher fileSystemWatcher;

//        #endregion

//        #region Constructor

//        public PlatformFileSystemWatcher()
//        {
//            this.fileSystemWatcher = new FileSystemWatcher();

//            this.fileSystemWatcher.Changed += FileSystemWatcher_Changed;
//            this.fileSystemWatcher.Created += FileSystemWatcher_Created;
//            this.fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
//        }

//        #endregion

//        #region Interface
        
//        public event EventHandler<IFileSystemWatcherChanged> Changed;

//        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
//        {
//            Debug.WriteLine("Changed event fired");
//            if (Changed != null)
//            {
//                this.Changed(sender, new PlatformFileSystemWatcherChanged(e));
//            }
//        }
        
//        public event EventHandler<IFileSystemWatcherChanged> Created;

//        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
//        {
//            Debug.WriteLine("Created event fired");
//            if (Created != null)
//            {
//                this.Created(sender, new PlatformFileSystemWatcherChanged(e));
//            }
//        }

//        public event EventHandler<IFileSystemWatcherChanged> Deleted;

//        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
//        {
//            Debug.WriteLine("Deleted event fired");
//            if (Deleted != null)
//            {
//                this.Deleted(sender, new PlatformFileSystemWatcherChanged(e));
//            }
//        }

//        public bool EnableRaisingEvents
//        {
//            get
//            {
//                return this.fileSystemWatcher.EnableRaisingEvents;
//            }

//            set
//            {
//                this.fileSystemWatcher.EnableRaisingEvents = value;
//            }
//        }

//        public string Filter
//        {
//            get
//            {
//                return this.fileSystemWatcher.Filter;
//            }

//            set
//            {
//                this.fileSystemWatcher.Filter = value;
//            }
//        }

//        public string Path
//        {
//            get
//            {
//                return this.fileSystemWatcher.Path;
//            }

//            set
//            {
//                this.fileSystemWatcher.Path = value;
//            }
//        }

//        public bool IncludeSubdirectories
//        {
//            get
//            {
//                return this.fileSystemWatcher.IncludeSubdirectories;
//            }

//            set
//            {
//                this.fileSystemWatcher.IncludeSubdirectories = value;
//            }
//        }

//        public void Dispose()
//        {
//            this.fileSystemWatcher.Changed -= FileSystemWatcher_Changed;
//            this.fileSystemWatcher.Created -= FileSystemWatcher_Created;
//            this.fileSystemWatcher.Deleted -= FileSystemWatcher_Deleted;

//            this.fileSystemWatcher.Dispose();
//        }

//        #endregion
//    }
//}
