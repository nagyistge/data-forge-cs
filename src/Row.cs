using System;
using System.Collections.Generic;
using System.Linq;

namespace Pancas
{
    /// <summary>
    /// Interface to a row in a data frame.
    /// </summary>
    public interface IRow
    {
        /// <summary>
        /// Get column value by colun name.
        /// </summary>
        T ByColumn<T>(string columnName);

        /// <summary>
        /// Get column value by column index.
        /// </summary>
        T ByColumn<T>(int columnIndex);
    }

    /// <summary>
    /// Interface to a row in a data frame.
    /// </summary>
    public struct Row : IRow 
    {
        /// <summary>
        /// The data frame that owns the row.
        /// </summary>
        private IDataFrame parentDataFrame;

        /// <summary>
        /// The column rows in the data frame row.
        /// </summary>
        private IColumnRow[] columns;

        public Row(IDataFrame parentDataFrame, IEnumerable<IColumnRow> columns)
        {
            this.parentDataFrame = parentDataFrame;
            this.columns = columns.ToArray();
        }

        /// <summary>
        /// Get column value by colun name.
        /// </summary>
        public T ByColumn<T>(string columnName)
        {
            return ByColumn<T>(parentDataFrame.GetColumnIndex(columnName)); //todo: handle bad column name
        }

        /// <summary>
        /// Get column value by column index.
        /// </summary>
        public T ByColumn<T>(int columnIndex)
        {
            return columns[columnIndex].As<T>();  //todo: handle bad column index
        }
    }

}