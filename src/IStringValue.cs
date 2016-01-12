using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    public interface IStringValue : IColumnValue
    {
        string GetValue();

        /// <summary>
        /// Parse the string value as a float.
        /// </summary>
        IFloatValue ParseFloat();
    }
}
