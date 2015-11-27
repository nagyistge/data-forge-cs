using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public class DataFrame : IDataFrame
    {
        private IColumn[] columns;

        public DataFrame()
        {

        }

        public DataFrame(IEnumerable<IColumn> columns)
        {
            this.columns = columns.ToArray();
        }

        public DataFrame(params IColumn[] columns)
        {
            this.columns = columns;
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
            return columns.Select(column => column.GetName());
        }

        public IEnumerable<IColumn> GetColumns()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<T1>> GetValues<T1>()
        {
            return columns[0]
                .GetValues<T1>()
                .Select(value => new Tuple<T1>(value));
        }

        public IEnumerable<Tuple<T1, T2>> GetValues<T1, T2>()
        {
            return LinqExts.Zip(
                columns[0].GetValues<T1>(), 
                columns[1].GetValues<T2>(), 
                (v1, v2) => new Tuple<T1, T2>(v1, v2)
            );
        }

        public IEnumerable<Tuple<T1, T2, T3>> GetValues<T1, T2, T3>()
        {
            return LinqExts.Zip(
                columns[0].GetValues<T1>(),
                columns[1].GetValues<T2>(),
                columns[2].GetValues<T3>(),
                (v1, v2, v3) => new Tuple<T1, T2, T3>(v1, v2, v3)
            );
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

        public IDataFrame SetColumn<T>(string columnName, IEnumerable<T> data)
        {
            throw new NotImplementedException();
        }

        public IDataFrame SetColumn(string columnName, IColumn column)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert index of the specified column.
        /// Returns -1 if the requested column doesn't exist.
        /// </summary>
        public int GetColumnIndex(string requestedColumnName)
        {
            var columnIndex = 0;
            foreach (var column in columns)
            {
                if (column.GetName() == requestedColumnName)
                {
                    return columnIndex;
                }

                ++columnIndex;
            }

            return -1;
        }

        public IEnumerator<IRow> GetEnumerator()
        {
            var enumerators = columns.Select(column => column.GetEnumerator()).ToArray();

            while (enumerators.All(enumerator => enumerator.MoveNext()))
            {
                yield return new Row(this, enumerators.Select(enumerator => enumerator.Current).Cast<IColumnRow>());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
