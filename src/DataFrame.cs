using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public class DataFrame : IDataFrame
    {
        private string[] columnNames;
        private object[] values;

        public DataFrame(string[] columnNames, object[] values)
        {
            this.columnNames = columnNames;
            this.values = values;
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

        public IEnumerable<string> GetColumnNames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IColumn> GetColumns()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<T1>> GetRows<T1>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<T1, T2>> GetRows<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<T1, T2, T3>> GetRows<T1, T2, T3>()
        {
            throw new NotImplementedException();
        }
    }
}
