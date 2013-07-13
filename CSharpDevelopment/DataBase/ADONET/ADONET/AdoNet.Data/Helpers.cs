using System.IO;

namespace AdoNet.Data
{
    public class Helpers
    {
        public static bool DirectoryExist(string DirectoryPatch)
        {
            DirectoryInfo objDirectory = new DirectoryInfo(DirectoryPatch);
            if (objDirectory.Exists)
            {
                return true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(DirectoryPatch);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}
