using Moq;
using Pancas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    public class RowTests
    {
        [Fact]
        public void can_get_column_value_by_index()
        {
            var data = new object[] { 1, "A" };
            var mockParentDataFrame = new Mock<IDataFrame>();
            var testObject = new Row(mockParentDataFrame.Object, data);

            Assert.Equal(1, testObject.ByColumn<int>(0));
            Assert.Equal("A", testObject.ByColumn<string>(1));
        }

        [Fact]
        public void can_get_column_value_by_name()
        {
            var data = new object[] { 1, "A" };
            var mockParentDataFrame = new Mock<IDataFrame>();
            var testObject = new Row(mockParentDataFrame.Object, data);

            var column1 = "Column1";
            mockParentDataFrame
                .Setup(m => m.GetColumnIndex(column1))
                .Returns(0);

            var column2 = "Column2";
            mockParentDataFrame
                .Setup(m => m.GetColumnIndex(column2))
                .Returns(1);

            Assert.Equal(1, testObject.ByColumn<int>("Column1"));
            Assert.Equal("A", testObject.ByColumn<string>("Column2"));
        }
    }
}
