﻿using System;
using Windows.Storage;


namespace Acr.IO {

    public class FileSystemImpl : IFileSystem {

        public FileSystemImpl() {
            StorageFolder.GetFolderFromPathAsync("").AsTask().ContinueWith(x => {
            });
        }

        public IDirectory AppData {
            get { throw new NotImplementedException(); }
        }

        public IDirectory Cache {
            get { throw new NotImplementedException(); }
        }

        public IDirectory Public {
            get { throw new NotImplementedException(); }
        }

        public IDirectory Temp {
            get { throw new NotImplementedException(); }
        }

        public IDirectory GetDirectory(string path) {
            throw new NotImplementedException();
        }

        public IFile GetFile(string path) {
            throw new NotImplementedException();
        }
    }
}