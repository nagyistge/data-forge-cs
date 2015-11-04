using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _1.plot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            Pancas.Pancas
                .From(new Pancas.DataSource.File("test.csv"))
                .As(new Pancas.DataFormat.Csv())
                .Then(dataFrame =>
                {
                    // Treat column 0 as index.
                    var dataFrameIndex = dataFrame.GetColumn(0).GetValues<int>().ToArray();

                    foreach (var column in dataFrame.GetColumns().Skip(1)) // Skip index.
                    {
                        var series = new Series(column.GetName());
                        var seriesData = dataFrameIndex.Zip(column.GetValues<int>(), (index, value) => new { index, value });
                        foreach (var data in seriesData)
                        {
                            series.Points.AddXY(data.index, data.value);
                        }
                    }
                });
        }
    }
}
