using System;

namespace _02.FileSystemTree
{
    public class File
    {
        private readonly string name;
        private readonly long size;

        public File(string name, long size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }
        }
    }
}
