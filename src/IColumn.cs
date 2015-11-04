using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public interface IColumn
    {
        /// <summary>
        /// Get the name of the column.
        /// </summary>
        string GetName();

        /// <summary>
        /// Get the values of the column.
        /// </summary>
        IEnumerable<T> GetValues<T>();
    }
}
