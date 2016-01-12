using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    /// <summary>
    /// A column that contains date values.
    /// </summary>
    public interface IDateColumn : IColumn
    {
        /// <summary>
        /// Pull the values out of the column.
        /// </summary>
        IEnumerable<DateTime> ToValues();
    }

    /// <summary>
    /// A column that contains date values.
    /// </summary>
    public class DateColumn : IDateColumn
    {
        /// <summary>
        /// Name of the column.
        /// </summary>
        private string name;

        /// <summary>
        /// Values in the column.
        /// </summary>
        private IEnumerable<DateTime> values;

        public DateColumn(string name)
        {
            this.name = name;
            this.values = new DateTime[0];
        }

        /*todo:
        public DateColumn(string name, IStringColumn origStringColumn)
        {
            this.name = name;
            this.values = values.ToArray();
        }
        */

        public DateColumn(string name, IEnumerable<DateTime> values)
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
        public IEnumerable<DateTime> ToValues()
        {
            return values;
        }
    }
}
