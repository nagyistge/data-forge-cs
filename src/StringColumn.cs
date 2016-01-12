using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    /// <summary>
    /// A column that contains strings.
    /// </summary>
    public interface IStringColumn : IColumn
    {
        /// <summary>
        /// Pull the values out of the column.
        /// </summary>
        IEnumerable<string> ToValues();
    }

    /// <summary>
    /// A column that contains strings.
    /// </summary>
    public class StringColumn : IStringColumn
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string name;

        /// <summary>
        /// Values in the column.
        /// </summary>
        private IEnumerable<string> values;

        public StringColumn(string name)
        {
            this.name = name;
            this.values = new string[0];
        }

        public StringColumn(string name, IEnumerable<string> values)
        {
            this.name = name;
            this.values = values.ToArray();
        }

        public IStringColumn AsString()
        {
            return this;
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
        public IEnumerable<string> ToValues()
        {
            return values;
        }

        public IFloatColumn AsFloat()
        {
            return new FloatColumn(name, values.Select(str => float.Parse(str)));
        }

        public IDoubleColumn AsDouble()
        {
            throw new NotImplementedException();
        }

        public IIntColumn AsInt()
        {
            throw new NotImplementedException();
        }

        public IDateColumn AsDate()
        {
            throw new NotImplementedException();
        }
    }
}
