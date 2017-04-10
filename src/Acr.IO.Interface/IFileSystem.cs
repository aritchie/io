using System;


namespace Acr.IO {

    public interface IFileSystem {

        IDirectory AppData { get; set; }
        IDirectory Cache { get; set; }
        IDirectory Public { get; set; }
        IDirectory Temp { get; set; }

        IDirectory GetDirectory(string path);
        IFile GetFile(string path);
    }
}
