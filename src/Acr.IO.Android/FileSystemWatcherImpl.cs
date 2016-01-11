using System;
using Android.OS;


namespace Acr.IO {

    public class FileSystemWatcherImpl {

        public FileSystemWatcherImpl() {
            var observer = new FileObserver("", FileObserverEvents.AllEvents);
        }
    }
}