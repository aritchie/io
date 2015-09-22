using System;
using System.Diagnostics;


namespace Acr.IO {

    public class FileViewerImpl : IFileViewer {

        public bool Open(IFile file) {
            var process = Process.Start(file.FullName);
            return process != null;
        }
    }
}
