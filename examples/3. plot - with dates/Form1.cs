using DataForge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            var maxRange = 14;
            var indexColumnName = "index";
            var dataFrame = new DataFrame(
                new Column<int>(indexColumnName, Enumerable.Range(0, maxRange)),
                new Column<double>("Sin", Enumerable.Range(0, maxRange).Select(i => Math.Sin(i))),
                new Column<double>("Cos", Enumerable.Range(0, maxRange).Select(i => Math.Cos(i)))
            );

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
                    var entries = LinqExts.Zip(
                            indexValues, 
                            column.GetValues<float>(), 
                            (index, value) => new { index, value }
                        )
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
