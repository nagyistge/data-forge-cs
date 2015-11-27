using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public interface IDataFrame
    {
        IEnumerable<Tuple<T1>> GetValues<T1>();
        IEnumerable<Tuple<T1, T2>> GetValues<T1, T2>();
        IEnumerable<Tuple<T1, T2, T3>> GetValues<T1, T2, T3>();

        IEnumerable<IRow> GetRows();

        /// <summary>
        /// Get names of the columns in the data frame.
        /// </summary>
        IEnumerable<string> GetColumnNames();

        IColumn GetColumn(string columnName);
        IColumn GetColumn(int columnIndex);

        IDataFrameSerializer As(IDataFormatPlugin dataFormatPlugin);

        IEnumerable<IColumn> GetColumns();

        IDataFrame DropColumn(string columnName);
        IDataFrame GetColumnsSubset(IEnumerable<string> columnNames);

        IDataFrame Where(Func<IRow, bool> rowPredicate);

        /// <summary>
        /// Convert index of the specified column.
        /// </summary>
        int GetColumnIndex(object columName);
    }
}
