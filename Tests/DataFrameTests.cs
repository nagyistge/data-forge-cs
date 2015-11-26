using Pancas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    public class DataFrameTests
    {
        [Fact]
        public void can_get_columns()
        {
            var columnNames = new string[]
            {
                "Column1",
                "Column2"
            };

            var dataFrame = new DataFrame(columnNames, new object[0][]);

            Assert.Equal(columnNames, dataFrame.GetColumnNames());
        }

        [Fact]
        public void can_get_values()
        {
            var columnNames = new string[]
            {
                "Column1",
                "Column2"
            };

            var inputValues = new object[][]
            {
                new object[]
                {
                    1, "A",
                },
                new object[]
                {
                    2, "B",
                },
            };

            var dataFrame = new DataFrame(columnNames, inputValues);

            var expectedValues = new Tuple<int, string>[]
            {
                new Tuple<int, string>(1, "A"),
                new Tuple<int, string>(2, "B"),
            };

            Assert.Equal(expectedValues, dataFrame.GetValues<int, string>());
        }
    }
}
