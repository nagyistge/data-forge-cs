using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    public class File : IDataSourcePlugin
    {
        private string filePath;

        public File(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
