using System;

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
        /// The data in the row.
        /// </summary>
        private object[] data;

        public Row(IDataFrame parentDataFrame, object[] data)
        {
            this.parentDataFrame = parentDataFrame;
            this.data = data;
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
            return (T)data[columnIndex]; //todo: handle bad column index
        }
    }

}