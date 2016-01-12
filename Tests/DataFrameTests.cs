using DataForge;
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
                new IntColumn("Column1"),
                new StringColumn("Column2")
            );

            var columnNames = new string[] { "Column1", "Column2" };
            Assert.Equal(columnNames, dataFrame.GetColumnNames());
        }

        [Fact]
        public void can_get_column_index()
        {
            var dataFrame = new DataFrame(
                new IntColumn("Column1"),
                new StringColumn("Column2")
            );

            Assert.Equal(0, dataFrame.GetColumnIndex("Column1"));
            Assert.Equal(1, dataFrame.GetColumnIndex("Column2"));
        }

        [Fact]
        public void can_get_index_of_non_existant_column()
        {
            var dataFrame = new DataFrame(
                new IntColumn("Column1"),
                new StringColumn("Column2")
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
                new IntColumn("Column1", new int[] { 1, 2 }),
                new StringColumn("Column2", new string[] { "A", "B" })
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
                .SetColumn("Column1", new IntColumn("Column1", new int[] { 1, 2 }))
                .SetColumn("Column2", new StringColumn("Column2", new string[] { "A", "B" }));

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
                new IntColumn("Column1", new int[] { 1, 2 }),
                new StringColumn("Column2", new string[] { "A", "B" })
            );
            var rows = dataFrame.GetRows().ToArray();
            /*todo:
            Assert.Equal(2, rows.Length);
            Assert.Equal(1, rows[0].ByColumn("Column1").As<int>());
            Assert.Equal(1, rows[0].ByColumn(0).As<int>());
            Assert.Equal("A", rows[0].ByColumn("Column2").As<string>());
            Assert.Equal("A", rows[0].ByColumn(1).As<string>());

            Assert.Equal(2, rows[1].ByColumn("Column1").As<int>());
            Assert.Equal(2, rows[1].ByColumn(0).As<int>());
            Assert.Equal("B", rows[1].ByColumn("Column2").As<string>());
            Assert.Equal("B", rows[1].ByColumn(1).As<string>());
            */
        }

    }
}
