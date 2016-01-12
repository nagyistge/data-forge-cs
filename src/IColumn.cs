using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataForge
{
    public interface IColumn
    {
        /// <summary>
        /// Get the name of the column.
        /// </summary>
        string GetName();

        /// <summary>
        /// Interpret the column as strings (doesn't convert, the column must already be strings).
        /// </summary>
        IStringColumn AsString();

        /// <summary>
        /// Interpret the column as floats.
        /// </summary>
        IFloatColumn AsFloat();

        /// <summary>
        /// Interpret the column as doubles.
        /// </summary>
        IDoubleColumn AsDouble();

        /// <summary>
        /// Interpret the column as integers.
        /// </summary>
        IIntColumn AsInt();

        /// <summary>
        /// Interpret the column as dates.
        /// </summary>
        IDateColumn AsDate();
    }
}
