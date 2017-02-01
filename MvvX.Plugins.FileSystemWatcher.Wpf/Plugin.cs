using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvX.Plugins.FileSystemWatcher.Wpf
{
    class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IFileSystemWatcher>(new PlatformFileSystemWatcher());
        }
    }
}
