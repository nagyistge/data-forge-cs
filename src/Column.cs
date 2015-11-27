using System;
using System.Collections;
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

        /// <summary>
        /// Get the rows from the column.
        /// </summary>
        IEnumerable<IColumnRow> GetRows();
    }

    /// <summary>
    /// A typed column.
    /// </summary>
    public class Column<T> : IColumn
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string name;

        /// <summary>
        /// Values in the column.
        /// </summary>
        private IEnumerable<T> values;

        public Column(string name, IEnumerable<T> values)
        {
            this.name = name;
            this.values = values.ToArray();
        }

        /// <summary>
        /// Get the rows from the column.
        /// </summary>
        public IEnumerable<IColumnRow> GetRows()
        {
            return values
                .Select(value => new ColumnRow<T>(value))
                .Cast<IColumnRow>();
        }

        /// <summary>
        /// Get the name of the column.
        /// </summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Get the values of the column.
        /// </summary>
        public IEnumerable<TT> GetValues<TT>()
        {
            return values.Cast<TT>();
        }
    }
}
