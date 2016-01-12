using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    /// <summary>
    /// A column that contains inting point values.
    /// </summary>
    public interface IIntColumn : IColumn
    {
        /// <summary>
        /// Pull the values out of the column.
        /// </summary>
        IEnumerable<int> ToValues();
    }

    /// <summary>
    /// A column that contains inting point values.
    /// </summary>
    public class IntColumn : IIntColumn
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string name;

        /// <summary>
        /// Values in the column.
        /// </summary>
        private IEnumerable<int> values;

        public IntColumn(string name)
        {
            this.name = name;
            this.values = new int[0];
        }

        /*todo:
        public IntColumn(string name, IStringColumn origStringColumn)
        {
            this.name = name;
            this.values = values.ToArray();
        }
        */

        public IntColumn(string name, IEnumerable<int> values)
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
        public IEnumerable<int> ToValues()
        {
            return values;
        }
    }
}
