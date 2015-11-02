using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public interface IDataFrame
    {
        IEnumerable<Tuple<T1>> Rows<T1>();
        IEnumerable<Tuple<T1, T2>> Rows<T1, T2>();
        IEnumerable<Tuple<T1, T2, T3>> Rows<T1, T2, T3>();

        IEnumerable<string> Columns();

        IColumn<T> Column<T>(string columnName);
        IColumn<T> Column<T>(int columnIndex);
    }
}
