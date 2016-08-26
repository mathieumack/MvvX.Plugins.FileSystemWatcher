namespace MvvX.Plugins.FileSystemWatcher.Events
{
    public interface IFileSystemWatcherChanged
    {
        /// <summary>
        /// Gets the type of directory event that occurred.
        /// </summary>
        WatcherChangeTypes ChangeType { get; }

        /// <summary>
        /// Gets the fully qualifed path of the affected file or directory.
        /// </summary>
        string FullPath { get; }

        /// <summary>
        /// Gets the name of the affected file or directory.
        /// </summary>
        string Name { get; }
    }
}
