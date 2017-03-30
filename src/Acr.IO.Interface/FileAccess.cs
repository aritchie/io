using System;


namespace Acr.IO
{
    public enum FileAccess
    {
        /// <summary>
        /// Read access to the file. Data can be read from the file. Combine with Write for read/write access.
        /// </summary>
        Read,

        /// <summary>
        /// Read and write access to the file. Data can be written to and read from the file.
        /// </summary>
        ReadWrite,

        /// <summary>
        /// Write access to the file. Data can be written to the file. Combine with Read for read/write access.
        /// </summary>
        Write
    }
}
