#if !NO_FILE
using SharpCompress.Common;
using System.Linq;

#endif

namespace SharpCompress.Archives
{
    public static class IArchiveExtensions
    {
#if !NO_FILE

        /// <summary>
        /// Extract to specific directory, retaining filename
        /// </summary>
        public static void WriteToDirectory(this IArchive archive, string destinationDirectory,
                                            ExtractionOptions options = null)
        {
            foreach (IArchiveEntry entry in archive.Entries.Where(x => !x.IsDirectory))
            {
                entry.WriteToDirectory(destinationDirectory, options);
            }
        }

        /// <summary>
        /// Extract files at selected indexex to specefic directory 
        /// </summary>
        public static void WriteToDirectory(this IArchive archive, string destinationDirectory, int[] indexes,
                                   ExtractionOptions options = null)
        {
            foreach (IArchiveEntry entry in archive.Entries.Where(x => !x.IsDirectory && indexes.Contains(x.Index)))
            {
                entry.WriteToDirectory(destinationDirectory, options);
            }
        }
#endif
    }
}