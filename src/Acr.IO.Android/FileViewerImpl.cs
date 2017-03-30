using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using Android.App;
using Android.Content;
using Env = Android.OS.Environment;


namespace Acr.IO
{

    public class FileViewerImpl : IFileViewer
    {
        private readonly string externalDirectory;


        public FileViewerImpl()
        {
            this.externalDirectory = Application.Context.GetExternalFilesDir(null).AbsolutePath;
        }


        public bool Open(IFile file)
        {
            try
            {
                // external apps do not have access to cache directory, copy from the cache to an external location
                var newPath = this.GetReadPath(file.Name);
                file.CopyTo(newPath);

                var javaFile = new Java.IO.File(newPath);
                var uri = Android.Net.Uri.FromFile(javaFile);
                var intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(uri, file.MimeType);
                if (!IsIntentManagable(intent))
                    return false;

                Application.Context.StartActivity(intent);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }


        private string GetReadPath(string fileName)
        {
            var fn = Path
                .GetFileName(fileName)
                .Replace('"', '_');

            var newPath = Path.Combine(this.externalDirectory, fn);
            return newPath;
        }


        private static bool IsIntentManagable(Intent intent)
        {
            return Application
                .Context
                .PackageManager
                .QueryIntentActivities(intent, Android.Content.PM.PackageInfoFlags.Activities)
                .Any();
        }
    }
}

