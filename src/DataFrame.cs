using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public class DataFrame : IDataFrame
    {
        private string[] columnNames;
        private object[][] rows;

        public DataFrame(string[] columnNames, object[][] rows)
        {
            this.columnNames = columnNames;
            this.rows = rows;
        }

        public IDataFrameSerializer As(IDataFormatPlugin dataFormatPlugin)
        {
            throw new NotImplementedException();
        }

        public IDataFrame DropColumn(string columnName)
        {
            throw new NotImplementedException();
        }

        public IColumn GetColumn(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public IColumn GetColumn(string columnName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get names of the columns in the data frame.
        /// </summary>
        public IEnumerable<string> GetColumnNames()
        {
            return columnNames;
        }

        public IEnumerable<IColumn> GetColumns()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<T1>> GetValues<T1>()
        {
            return rows.Select(row => new Tuple<T1>((T1)row[0]));
        }

        public IEnumerable<Tuple<T1, T2>> GetValues<T1, T2>()
        {
            return rows.Select(row => new Tuple<T1, T2>((T1)row[0], (T2)row[1]));
        }

        public IEnumerable<Tuple<T1, T2, T3>> GetValues<T1, T2, T3>()
        {
            return rows.Select(row => new Tuple<T1, T2, T3>((T1)row[0], (T2)row[1], (T3)row[2]));
        }

        public IEnumerable<IRow> GetRows()
        {
            return rows.Select(row => new Row(this, row)).Cast<IRow>();
        }

        public IDataFrame GetColumnsSubset(IEnumerable<string> columnNames)
        {
            throw new NotImplementedException();
        }

        public IDataFrame Where(Func<IRow, bool> rowPredicate)
        {
            throw new NotImplementedException();
        }

        new public string ToString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert index of the specified column.
        /// Returns -1 if the requested column doesn't exist.
        /// </summary>
        public int GetColumnIndex(object requestedColumnName)
        {
            return columnNames.IndexOf(requestedColumnName);
        }
    }
}
