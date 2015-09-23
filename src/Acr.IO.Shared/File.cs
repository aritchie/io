#if __PLATFORM__
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Acr.IO {

    public class File : FileSystemObject, IFile {
        readonly FileInfo info;


        public File(string fileName) : this(new FileInfo(fileName)) {}
        internal File(FileInfo info) : base(info) {
            this.info = info;
        }


        private string mimeType;
        public string MimeType {
            get {
                this.mimeType = this.mimeType ?? GetMimeType();
                return this.mimeType;
            }
        }


        public long Length => this.info.Length;


        public Stream Create() {
            return this.info.Create();
        }


        public Stream OpenRead() {
            return this.info.OpenRead();
        }


        public Stream OpenWrite() {
            return this.info.OpenWrite();
        }


        public void MoveTo(string path) {
            this.info.MoveTo(path);
        }


        public IFile CopyTo(string path, bool overwrite) {
            var create = this.info.CopyTo(path, overwrite);
            return new File(create);
        }


        public async Task<IFile> CopyToAsync(string path, bool overwrite, Action<FileCopyProgress> onProgress, CancellationToken token) {
            var create = new File(path);
            if (overwrite)
                create.DeleteIfExists();

            var buffer = new byte[65535];
            var totalCopy = 0;
            var start = DateTime.UtcNow;

            using (var readStream = this.OpenRead()) {
                using (var writeStream = create.Create()) {

                    var read = await readStream.ReadAsync(buffer, 0, buffer.Length, token);
                    while (read > 0 && !token.IsCancellationRequested) {
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


        Directory directory;
        public IDirectory Directory {
            get {
                this.directory = this.directory ?? new Directory(this.info.Directory);
                return this.directory;
            }
        }


        string GetMimeType() {
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