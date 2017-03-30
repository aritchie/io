#if __PLATFORM__
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using N = System.IO;


namespace Acr.IO
{

    public class File : IFile
    {
        readonly FileInfo info;


        public File(string fileName) : this(new FileInfo(fileName)) { }
        internal File(FileInfo info)
        {
            this.info = info;
        }

#region IFile Members

        public string Name => this.info.Name;
        public string FullName => this.info.FullName;
        public string Extension => this.info.Extension;
        public bool Exists => this.info.Exists;
        public long Length => this.info.Length;
        public DateTime LastAccessTime => this.info.LastAccessTime;
        public DateTime LastWriteTime => this.info.LastWriteTime;
        public DateTime CreationTime => this.info.CreationTime;


        string mimeType;
        public string MimeType
        {
            get
            {
                this.mimeType = this.mimeType ?? this.GetMimeType();
                return this.mimeType;
            }
        }


        Directory directory;
        public IDirectory Directory
        {
            get
            {
                this.directory = this.directory ?? new Directory(this.info.Directory);
                return this.directory;
            }
        }


        public Stream Create() => this.info.Create();
        public Stream OpenRead() => this.info.OpenRead();
        public Stream OpenWrite() => this.info.OpenWrite();

        public Stream Open(FileMode mode) => this.info.Open
        (
            (N.FileMode)Enum.Parse(typeof(N.FileMode), mode.ToString())
        );
        public Stream Open(FileMode mode, FileAccess access) => this.info.Open
        (
            (N.FileMode)Enum.Parse(typeof(N.FileMode), mode.ToString()),
            (N.FileAccess)Enum.Parse(typeof(N.FileAccess), access.ToString())
        );
        public Stream Open(FileMode mode, FileAccess access, FileShare share) => this.info.Open
        (
            (N.FileMode)Enum.Parse(typeof(N.FileMode), mode.ToString()),
            (N.FileAccess)Enum.Parse(typeof(N.FileAccess), access.ToString()),
            (N.FileShare)Enum.Parse(typeof(N.FileShare), share.ToString())
        );

        public StreamReader OpenText() => this.info.OpenText();
        public void MoveTo(string path) => this.info.MoveTo(path);
        public void Delete() => this.info.Delete();
        public IFile CopyTo(string path)
        {
            var file = this.info.CopyTo(path);
            return new File(file);
        }


        public async Task<IFile> CopyToAsync(string path, bool overwrite, Action<FileCopyProgress> onProgress, CancellationToken token)
{
            var create = new File(path);
            if (overwrite)
                create.DeleteIfExists();

            var buffer = new byte[65535];
            var totalCopy = 0;
            var start = DateTime.UtcNow;

            using (var readStream = this.OpenRead())
            {
                using (var writeStream = create.Create())
                {
                    var read = await readStream.ReadAsync(buffer, 0, buffer.Length, token);
                    while (read > 0 && !token.IsCancellationRequested)
                    {
                        await writeStream.WriteAsync(buffer, 0, read, token);
                        read = await readStream.ReadAsync(buffer, 0, buffer.Length, token);
                        totalCopy += read;
                        onProgress?.Invoke(new FileCopyProgress(totalCopy, this.Length, start));
                    }
                }
            }
            if (token.IsCancellationRequested)
                create.DeleteIfExists();

            return new File(path);
        }

#endregion


        string GetMimeType()
        {
            var ext = Path.GetExtension(this.Name);

#if __ANDROID__
			if (ext == null)
				return "*.*";

			ext = ext.ToLower().TrimStart('.');
			var mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(ext);
			return mimeType ?? "*.*";
#else
            //			if (ext == null)
            //				return String.Empty;
            //
            //			switch (ext.ToLower()) {
            //			case ".jpg" : return "image/jpg";
            //			case ".png" : return "image/png";
            //			case ".gif" : return "image/gif";
            //			case ".pdf" : return "application/pdf";
            //			case ".docs": return "application/";
            //			}
            return String.Empty;
#endif
        }
    }
}
#endif