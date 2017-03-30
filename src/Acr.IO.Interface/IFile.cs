using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.IO
{

    public interface IFile
    {

        string Name { get; }
        string FullName { get; }
        string Extension { get; }
        long Length { get; }
        bool Exists { get; }
        string MimeType { get; }

        Stream Create();
        Stream OpenRead();
        Stream OpenWrite();
        Stream Open(FileMode mode);
        Stream Open(FileMode mode, FileAccess access);
        Stream Open(FileMode mode, FileAccess access, FileShare share);
        StreamReader OpenText();

        void MoveTo(string path);
        IFile CopyTo(string path);
        void Delete();
        Task<IFile> CopyToAsync(string path, bool overwrite = false, Action<FileCopyProgress> onProgress = null, CancellationToken cancelToken = default(CancellationToken));

        IDirectory Directory { get; }
        DateTime LastAccessTime { get; }
        DateTime LastWriteTime { get; }
        DateTime CreationTime { get; }
    }
}
