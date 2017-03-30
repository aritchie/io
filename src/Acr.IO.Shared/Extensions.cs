using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Acr.IO
{

    public static class Extensions
    {

        /// <summary>
        /// This will return a file location whether or not it exists
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IFile GetFile(this IDirectory directory, string fileName)
            => directory.GetExistingFile(fileName) ?? directory.CreateFile(fileName);


        public static IFile GetExistingFile(this IDirectory directory, string fileName)
            => directory
                .Files
                .FirstOrDefault(x => x.Name.Equals(fileName, StringComparison.Ordinal));


        public static void DeleteIfExists(this IFile file)
        {
            if (file.Exists)
                file.Delete();
        }


        public static Task<Stream> OpenWriteAsync(this IFile file) => Task<Stream>.Factory.StartNew(file.OpenWrite);
        public static Task<Stream> OpenReadAsync(this IFile file) => Task<Stream>.Factory.StartNew(file.OpenRead);
    }
}
