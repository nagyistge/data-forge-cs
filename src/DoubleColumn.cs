using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    /// <summary>
    /// A column that contains double-precision doubleing point values.
    /// </summary>
    public interface IDoubleColumn : IColumn
    {
        /// <summary>
        /// Pull the values out of the column.
        /// </summary>
        IEnumerable<double> ToValues();
    }

    /// <summary>
    /// A column that contains double-precision doubleing point values.
    /// </summary>
    public class DoubleColumn : IDoubleColumn
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string name;

        /// <summary>
        /// Values in the column.
        /// </summary>
        private IEnumerable<double> values;

        public DoubleColumn(string name)
        {
            this.name = name;
            this.values = new double[0];
        }

        /*todo:
        public DoubleColumn(string name, IStringColumn origStringColumn)
        {
            this.name = name;
            this.values = values.ToArray();
        }
        */

        public DoubleColumn(string name, IEnumerable<double> values)
        {
            this.name = name;
            this.values = values.ToArray();
        }

        public IDateColumn AsDate()
        {
            throw new NotImplementedException();
        }

        public IDoubleColumn AsDouble()
        {
            throw new NotImplementedException();
        }

        public IFloatColumn AsFloat()
        {
            throw new NotImplementedException();
        }

        public IIntColumn AsInt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert the column to strings.
        /// </summary>
        public IStringColumn AsString()
        {
            return new StringColumn(name, values.Select(value => value.ToString()));
        }

        /// <summary>
        /// Get the name of the column.
        /// </summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Pull the values out of the column.
        /// </summary>
        public IEnumerable<double> ToValues()
        {
            return values;
        }
    }
}
