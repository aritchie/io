using System;


namespace Acr.IO
{
    public static class FileViewer
    {
        static IFileViewer current;
        public static IFileViewer Current
        {
            get
            {
#if PCL
                if (current == null)
                    throw new Exception("[Acr.IO] Platform implementation not found.  Have you added a nuget reference to your platform project?");
#else
                current = current ?? new FileViewerImpl();
#endif
                return current;
            }
            set { current = value; }
        }
    }
}