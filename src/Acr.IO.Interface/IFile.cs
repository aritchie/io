using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.IO {

    public interface IFile : IFileSystemObject {

        long Length { get; }
        string MimeType { get; }

        Stream Create();
        Stream OpenRead();
        Stream OpenWrite();
        void MoveTo(string path);
        IFile CopyTo(string path, bool overwrite = false);
        Task<IFile> CopyToAsync(string path, bool overwrite = false, Action<FileCopyProgress> onProgress = null, CancellationToken cancelToken = default(CancellationToken));

        IDirectory Directory { get; }
    }
}
