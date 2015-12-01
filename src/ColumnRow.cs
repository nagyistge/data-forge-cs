using System;

namespace DataForge
{
    /// <summary>
    /// Represents a row in a column.
    /// </summary>
    public interface IColumnRow
    {
        /// <summary>
        /// Retrieve the value in the row.
        /// </summary>
        T As<T>();
    }

    /// <summary>
    /// Represents a row in a column.
    /// </summary>
    public struct ColumnRow<T> : IColumnRow
    {
        /// <summary>
        /// The value in this row of the column.
        /// </summary>
        private T value;

        public ColumnRow(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Retrieve the value in the row.
        /// </summary>
        public TT As<TT>()
        {
            return (TT)(object)value;
        }
    }
}