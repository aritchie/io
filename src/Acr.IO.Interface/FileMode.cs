using System;


namespace Acr.IO
{
    public enum FileMode
    {
        /// <summary>
        /// Opens the file if it exists and seeks to the end of the file, or creates a new file. System.IO.FileMode.Append can only be used in conjunction with System.IO.FileAccess.Write. Attempting to seek to a position before the end of the file will throw an System.IO.IOException and any attempt to read fails and throws an System.NotSupportedException.
        /// </summary>
        Append,

        /// <summary>
        /// Specifies that the operating system should create a new file. If the file already exists, it will be overwritten. System.IO.FileMode.Create is equivalent to requesting that if the file does not exist, use System.IO.FileMode.CreateNew; otherwise, use System.IO.FileMode.Truncate.
        /// </summary>
        Create,

        /// <summary>
        /// Specifies that the operating system should create a new file
        /// </summary>
        CreateNew,

        /// <summary>
        /// Specifies that the operating system should open an existing file. The ability to open the file is dependent on the value specified by System.IO.FileAccess. A System.IO.FileNotFoundException is thrown if the file does not exist.
        /// </summary>
        Open,

        /// <summary>
        /// Specifies that the operating system should open a file if it exists; otherwise, a new file should be created.
        /// </summary>
        OpenOrCreate,

        /// <summary>
        /// Specifies that the operating system should open an existing file. Once opened, the file should be truncated so that its size is zero bytes.
        /// </summary>
        Truncate
    }
}
