using System;


namespace Acr.IO {

    public interface IFileSystemObject {

        string Name { get; }
        string FullName { get; }
        string Extension { get; }
        bool Exists { get; }
        DateTime LastAccessTime { get; }
        DateTime LastWriteTime { get; }
        DateTime CreationTime { get; }
        void Refresh();
        void Delete();
    }
}
