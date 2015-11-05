using Pancas;
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
                .From(new Pancas.DataSource.File("share_prices.csv"))
                .As(new Pancas.DataFormat.Csv())
                .Then(dataFrame =>
                {
                    Plot("Date", dataFrame);
                });
        }

        /// <summary>
        /// Helper function for plotting.
        /// </summary>
        private void Plot(string indexColumnName, IDataFrame dataFrame)
        {
            var indexValues = dataFrame.GetColumn(indexColumnName).GetValues<int>();
            var remainingColumns = dataFrame.DropColumn("index").GetColumns();

            var allSeriesData = remainingColumns
                .Select(column =>
                {
                    var label = column.GetName();
                    var entries = indexValues
                        .Zip(column.GetValues<float>(), (index, value) => new { index, value })
                        .ToArray();

                    return new { label, entries };
                })
                .ToArray();

            foreach (var seriesData in allSeriesData)
            {
                var series = new Series(seriesData.label);
                foreach (var entry in seriesData.entries)
                {
                    series.Points.AddXY(entry.index, entry.value);
                }
            }
        }
    }
}
