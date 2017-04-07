#if __PLATFORM__
using System;
using System.IO;

#if __IOS__
using UIKit;
using Foundation;
#endif

namespace Acr.IO
{

    public class FileSystemImpl : IFileSystem
    {

        public FileSystemImpl()
        {
#if WINDOWS_UWP
            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            this.AppData = new Directory(path);
            this.Cache = new Directory(Path.Combine(path, "Cache"));
            this.Public = new Directory(Path.Combine(path, "Public"));
            this.Temp = new Directory(Path.Combine(path, "Temp"));
#elif __IOS__
            var documents = UIDevice.CurrentDevice.CheckSystemVersion(8, 0)
                ? NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path
                : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var library = Path.Combine(documents, "..", "Library");
            this.AppData = new Directory(library);
            this.Cache = new Directory(Path.Combine(library, "Caches"));
            this.Temp = new Directory(Path.Combine(documents, "..", "tmp"));
            this.Public = new Directory(documents);
#elif __ANDROID__
            try {
                var ctx = Android.App.Application.Context;
                this.AppData = new Directory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

                var ext = ctx.GetExternalFilesDir(null);
                if (ext != null)
                    this.Public = new Directory(ext.AbsolutePath);

                var cacheDir = ctx.GetExternalFilesDir(null);
                if (cacheDir != null) {
                    this.Cache = new Directory(cacheDir.AbsolutePath);
                    this.Temp = new Directory(cacheDir.AbsolutePath);
                }
            }
            catch { }
#endif
        }


        public IDirectory AppData { get; set; }
        public IDirectory Cache { get; set; }
        public IDirectory Public { get; set; }
        public IDirectory Temp { get; set; }


        public IDirectory GetDirectory(string path) => new Directory(new DirectoryInfo(path));
        public IFile GetFile(string fileName) => new File(new FileInfo(fileName));
    }
}
#endif