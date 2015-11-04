using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas.DataSource
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
