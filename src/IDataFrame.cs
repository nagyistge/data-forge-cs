using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public interface IDataFrame
    {
        IEnumerable<Tuple<T1>> GetRows<T1>();
        IEnumerable<Tuple<T1, T2>> GetRows<T1, T2>();
        IEnumerable<Tuple<T1, T2, T3>> GetRows<T1, T2, T3>();

        IEnumerable<string> GetColumnNames();

        IColumn GetColumn(string columnName);
        IColumn GetColumn(int columnIndex);

        IDataFrameSerializer As(IDataFormatPlugin dataFormatPlugin);

        IEnumerable<IColumn> GetColumns();

        IDataFrame DropColumn(string columnName);
        IDataFrame Subset(IEnumerable<string> columnNames);
    }
}
