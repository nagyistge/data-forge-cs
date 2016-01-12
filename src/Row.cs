using System;
using System.Collections.Generic;
using System.Linq;

namespace DataForge
{
    /// <summary>
    /// Interface to a row in a data frame.
    /// </summary>
    public interface IRow
    {
        /// <summary>
        /// Get column value by colun name.
        /// </summary>
        IColumnValue ByColumn(string columnName);

        /// <summary>
        /// Get column value by column index.
        /// </summary>
        IColumnValue ByColumn(int columnIndex);
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
        private IColumnValue[] columns;

        public Row(IDataFrame parentDataFrame, IEnumerable<IColumnValue> columns)
        {
            this.parentDataFrame = parentDataFrame;
            this.columns = columns.ToArray();
        }

        /// <summary>
        /// Get column value by colun name.
        /// </summary>
        public IColumnValue ByColumn(string columnName)
        {
            return ByColumn(parentDataFrame.GetColumnIndex(columnName)); //todo: handle bad column name
        }

        /// <summary>
        /// Get column value by column index.
        /// </summary>
        public IColumnValue ByColumn(int columnIndex)
        {
            return columns[columnIndex];  //todo: handle bad column index
        }
    }

}