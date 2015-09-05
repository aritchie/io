using System;


namespace Acr.IO {

    public static class FileViewer {
        static Lazy<IFileViewer> instance = new Lazy<IFileViewer>(() => {
#if PCL
            throw new Exception("Platform implementation not found.  Have you added a nuget reference to your platform project?");
#else
            return new FileViewerImpl();
#endif
        });


        static IFileViewer customInstance;
        public static IFileViewer Instance {
            get { return customInstance ?? instance.Value;  }
            set { customInstance = value; }
        }
    }
}