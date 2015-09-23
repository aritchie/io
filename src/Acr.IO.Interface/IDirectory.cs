using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Acr.IO {

    public interface IDirectory : IFileSystemObject {

        Task<IEnumerable<IFileSystemObject>> GetFileSystemObjectsAsync(string pattern = null, FsSearchOption option = FsSearchOption.TopDirectoryOnly);
        Task<IEnumerable<IFile>> GetFilesAsync(string pattern = null, FsSearchOption option = FsSearchOption.TopDirectoryOnly);
        Task<IEnumerable<IDirectory>> GetDirectoriesAsync(string pattern = null, FsSearchOption option = FsSearchOption.TopDirectoryOnly);
        //Task CopyToAsync(string path, Action<DirectoryCopyProgress> onProgress = null, CancellationToken cancelToken = default(CancellationToken));


        IDirectory Root { get; }
        IDirectory Parent { get; }

        void Create();
        void MoveTo(string path);
        void Delete(bool recursive = false);

        bool FileExists(string fileName);
        IFile CreateFile(string name);
        IDirectory CreateSubdirectory(string name);
        IEnumerable<IDirectory> Directories { get; }
        IEnumerable<IFile> Files { get; }
    }
}
