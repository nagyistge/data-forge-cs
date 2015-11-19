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

            // 
            // Create a simple data frame.
            //
            var values = Enumerable.Range(0, 14)
                .Select(i => new
                {
                    index = new DateTime(2015, 3, i),
                    sin = Math.Sin(i),
                    cos = Math.Cos(i)
                })
    		    .ToArray();

            var indexColumnName = "index";
            var columnNames = new string[] { indexColumnName, "Sin", "Cos" };
            var dataFrame = new DataFrame(columnNames, values);

            //
            // Plot the data frame.
            //
            Plot(indexColumnName, dataFrame);           
        }

        /// <summary>
        /// Helper function for plotting.
        /// </summary>
        private void Plot(string indexColumnName, IDataFrame dataFrame)
        {
            var indexValues = dataFrame.GetColumn(indexColumnName).GetValues<DateTime>();
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

                chart1.Series.Add(series);
            }            
        }
    }
}
