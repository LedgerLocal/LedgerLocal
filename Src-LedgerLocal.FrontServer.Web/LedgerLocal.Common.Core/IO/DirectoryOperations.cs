using System.IO;

namespace LedgerLocal.Common.Core
{
    public class DirectoryOperations
    {
        public static void CheckForCreateDirectory(string pathDir)
        {
            if (!Directory.Exists(pathDir))
            {
                Directory.CreateDirectory(pathDir);
            }
        }
    }
}
