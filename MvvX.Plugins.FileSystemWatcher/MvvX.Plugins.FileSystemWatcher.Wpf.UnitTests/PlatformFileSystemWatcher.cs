using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvX.Plugins.FileSystemWatcher;
using MvvX.Plugins.FileSystemWatcher.Wpf;

namespace MvvX.Plugins.FileSystemWatcher.Wpf.UnitTests
{
    [TestClass]
    public class PlatformFileSystemWatcher
    {
        private int nbEvents = 0;
        private bool isCreated = false;
        private bool isChanged = false;
        private bool isDeleted = false;

        [TestMethod]
        public void FileSystemWatcher_Create()
        {
            using (IFileSystemWatcher watcher = new Wpf.PlatformFileSystemWatcher())
            {
                var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                watcher.Path = baseDir;
                watcher.Created += Watcher_Created;
                watcher.Changed += Watcher_Changed;
                watcher.Deleted += Watcher_Deleted;

                // Start watch
                watcher.EnableRaisingEvents = true;

                // On va maintenant créer un fichier :
                File.WriteAllText(Path.Combine(baseDir, "testFile.txt"), "Unit test file");

                // On va attendre que l'event soit levé.
                int nbTry = 0;
                while (nbEvents == 0 && nbTry < 50)
                {
                    Thread.Sleep(500);
                    nbTry++;
                }

                Assert.IsTrue(isCreated || isChanged);

                nbEvents = 0;
                // On va maintenant supprimer le fichier :
                File.Delete(Path.Combine(baseDir, "testFile.txt"));

                nbTry = 0;
                while (nbEvents == 0 && nbTry < 50)
                {
                    Thread.Sleep(500);
                    nbTry++;
                }

                Assert.IsTrue(isDeleted);
            }
        }
        

        private void Watcher_Created(object sender, FileSystemWatcher.Events.IFileSystemWatcherChanged e)
        {
            isCreated = e.ChangeType == WatcherChangeTypes.Created;
            nbEvents++;
        }

        private void Watcher_Changed(object sender, FileSystemWatcher.Events.IFileSystemWatcherChanged e)
        {
            isChanged = e.ChangeType == WatcherChangeTypes.Changed;
            nbEvents++;
        }

        private void Watcher_Deleted(object sender, FileSystemWatcher.Events.IFileSystemWatcherChanged e)
        {
            isDeleted = e.ChangeType == WatcherChangeTypes.Deleted;
            nbEvents++;
        }
    }
}
