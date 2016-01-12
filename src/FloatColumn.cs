using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    /// <summary>
    /// A column that contains single-precision floating point values.
    /// </summary>
    public interface IFloatColumn : IColumn
    {
        /// <summary>
        /// Pull the values out of the column.
        /// </summary>
        IEnumerable<float> ToValues();
    }

    /// <summary>
    /// A column that contains single-precision floating point values.
    /// </summary>
    public class FloatColumn : IFloatColumn
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string name;

        /// <summary>
        /// Values in the column.
        /// </summary>
        private IEnumerable<float> values;

        public FloatColumn(string name)
        {
            this.name = name;
            this.values = new float[0];
        }

        /*todo:
        public FloatColumn(string name, IStringColumn origStringColumn)
        {
            this.name = name;
            this.values = values.ToArray();
        }
        */

        public FloatColumn(string name, IEnumerable<float> values)
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
        public IEnumerable<float> ToValues()
        {
            return values;
        }
    }
}
