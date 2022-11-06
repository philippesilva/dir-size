namespace DirSize
{
    public static class TreeSizeConsole
    {
        public static string Format(long bytes)
        {
            string filesize;
            if (bytes >= 1073741824)
            {
                decimal size = decimal.Divide(bytes, 1073741824);
                filesize = string.Format("{0:##.##} GB", size);
            }
            else if (bytes >= 1048576)
            {
                decimal size = decimal.Divide(bytes, 1048576);
                filesize = string.Format("{0:##.##} MB", size);
            }
            else if (bytes >= 1024)
            {
                decimal size = decimal.Divide(bytes, 1024);
                filesize = string.Format("{0:##.##} KB", size);
            }
            else if (bytes > 0 && bytes < 1024)
            {
                decimal size = bytes;
                filesize = string.Format("{0:##.##} Bytes", size);
            }
            else
            {
                filesize = "0 Bytes";
            }
            return filesize;
        }
    }
}
