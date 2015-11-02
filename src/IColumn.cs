using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancas
{
    public interface IColumn<T>
    {
        string Name { get; }

        IEnumerable<T> Values();
    }
}
