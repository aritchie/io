using System;


namespace Acr.IO
{

    public static class FileSystem
    {
        static IFileSystem current;
        public static IFileSystem Current
        {
            get
            {
#if PCL
                if (current == null)
                    throw new Exception("[Acr.IO] Platform implementation not found.  Have you added a nuget reference to your platform project?");
#else
                current = current ?? new FileSystemImpl();
#endif
                return current;
            }
            set { current = value; }
        }
    }
}
