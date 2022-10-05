using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystemDemo.UIModels
{
    internal class GraphRestart
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }

        public object BuildGraph()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<int> { 12,2,4,5,24,28,38,35,66,37,33,7 }
                }
            };

            //adding series will update and animate the chart automatically
            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "2016",
            //    Values = new ChartValues<double> { 11, 56, 42 }
            //});

            ////also adding values updates and animates the chart automatically
            //SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "ЯНВ", "ФЕВ", "МАР", "АПР", "МАЙ", "ИЮН", "ИЮЛ", "АВГ", "СЕН", "ОКТ", "НОЯ", "ДЕК" };

            return this;
        }
    }
}
