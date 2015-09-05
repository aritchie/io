using System;


namespace Acr.IO {

    public static class FileSystem {
        static Lazy<IFileSystem> instance = new Lazy<IFileSystem>(() => {
#if PCL
            throw new Exception("Platform implementation not found.  Have you added a nuget reference to your platform project?");
#else
            return new FileSystemImpl();
#endif
        });


        static IFileSystem customInstance;
        public static IFileSystem Instance {
            get { return customInstance ?? instance.Value; }
            set { customInstance = value; }
        }
    }
}
