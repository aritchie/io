#if __PLATFORM__
using System;
using System.IO;


namespace Acr.IO {

    public class FileSystemObject : IFileSystemObject {
        readonly FileSystemInfo info;


        public FileSystemObject(FileSystemInfo info) {
            this.info = info;
        }


        public string Name => this.info.Name;
        public string FullName => this.info.FullName;
        public string Extension => this.info.Extension;
        public bool Exists => this.info.Exists;

        public DateTime LastAccessTime => this.info.LastAccessTimeUtc;
        public DateTime LastWriteTime => this.info.LastWriteTimeUtc;
        public DateTime CreationTime => this.info.CreationTimeUtc;


        public void Delete() {
            this.info.Delete();
        }


        public void Refresh() {
            this.info.Refresh();
        }
    }
}
#endif