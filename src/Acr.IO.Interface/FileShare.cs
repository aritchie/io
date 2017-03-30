using System;


namespace Acr.IO
{
    public enum FileShare
    {
        /// <summary>
        /// Allows subsequent deleting of a file.
        /// </summary>
        Delete,

        /// <summary>
        /// Makes the file handle inheritable by child processes.
        /// </summary>
        Inheritable,

        /// <summary>
        /// Declines sharing of the current file. Any request to open the file (by this process or another process) will fail until the file is closed.
        /// </summary>
        None,

        /// <summary>
        /// Allows subsequent opening of the file for reading. If this flag is not specified, any request to open the file for reading (by this process or another process) will fail until the file is closed.
        /// </summary>
        Read,

        /// <summary>
        /// Allows subsequent opening of the file for reading or writing. If this flag is not specified, any request to open the file for reading or writing (by this process or another process) will fail until the file is closed.
        /// </summary>
        ReadWrite,

        /// <summary>
        /// Allows subsequent opening of the file for writing. If this flag is not specified, any request to open the file for writing (by this process or another process) will fail until the file is closed.
        /// </summary>
        Write
    }
}
