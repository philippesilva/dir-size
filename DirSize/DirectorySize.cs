using DirSize.Models;

namespace DirSize
{
    public static class DirectorySize
    {
        public static DirectorySizeInfo[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path)
                .Select(directory => new DirectoryInfo(directory))
                .Select(directoryInfo => new DirectorySizeInfo(directoryInfo, GetSize(directoryInfo)))
                .ToArray();
        }

        public static long GetSize(DirectoryInfo directoryInfo)
        {
            long size = 0;

            // Add file sizes.
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo fi in files)
                size += fi.Length;

            // Add subdirectory sizes.
            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            foreach (DirectoryInfo di in directories)
                size += GetSize(di);

            return size;
        }
    }
}
