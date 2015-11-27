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
            var dataFrame = new DataFrame(
                new Column<int>("Column1", new int[0]),
                new Column<string>("Column2", new string[0])
            );

            var columnNames = new string[] { "Column1", "Column2" };
            Assert.Equal(columnNames, dataFrame.GetColumnNames());
        }

        [Fact]
        public void can_get_column_index()
        {
            var dataFrame = new DataFrame(
                new Column<int>("Column1", new int[0]),
                new Column<string>("Column2", new string[0])
            );

            Assert.Equal(0, dataFrame.GetColumnIndex("Column1"));
            Assert.Equal(1, dataFrame.GetColumnIndex("Column2"));
        }

        [Fact]
        public void can_get_index_of_non_existant_column()
        {
            var dataFrame = new DataFrame(
                new Column<int>("Column1", new int[0]),
                new Column<string>("Column2", new string[0])
            );

            Assert.Equal(-1, dataFrame.GetColumnIndex("non-existant-column"));
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

            var dataFrame = new DataFrame(
                new Column<int>("Column1", new int[] { 1, 2 }),
                new Column<string>("Column2", new string[] { "A", "B" })
            );

            var expectedValues = new Tuple<int, string>[]
            {
                new Tuple<int, string>(1, "A"),
                new Tuple<int, string>(2, "B"),
            };

            Assert.Equal(expectedValues, dataFrame.GetValues<int, string>());
        }

        [Fact]
        public void can_get_values_from_set_columns()
        {
            var dataFrame = new DataFrame()
                .SetColumn<int>("Column1", new int[] { 1, 2 })
                .SetColumn<string>("Column2", new string[] { "A", "B" });

            var columnNames = new string[] { "Column1", "Column2" };
            Assert.Equal(columnNames, dataFrame.GetColumnNames());

            var expectedValues = new Tuple<int, string>[]
            {
                new Tuple<int, string>(1, "A"),
                new Tuple<int, string>(2, "B"),
            };

            Assert.Equal(expectedValues, dataFrame.GetValues<int, string>());
        }

        [Fact]
        public void can_get_rows()
        {
            var dataFrame = new DataFrame(
                new Column<int>("Column1", new int[] { 1, 2 }),
                new Column<string>("Column2", new string[] { "A", "B" })
            );
            var rows = dataFrame.GetRows().ToArray();
            Assert.Equal(2, rows.Length);
            Assert.Equal(1, rows[0].ByColumn<int>("Column1"));
            Assert.Equal(1, rows[0].ByColumn<int>(0));
            Assert.Equal("A", rows[0].ByColumn<string>("Column2"));
            Assert.Equal("A", rows[0].ByColumn<string>(1));

            Assert.Equal(2, rows[1].ByColumn<int>("Column1"));
            Assert.Equal(2, rows[1].ByColumn<int>(0));
            Assert.Equal("B", rows[1].ByColumn<string>("Column2"));
            Assert.Equal("B", rows[1].ByColumn<string>(1));
        }

    }
}
