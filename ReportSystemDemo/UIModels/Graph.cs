using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystemDemo.UIModels
{
    internal class Graph
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }
        public SeriesCollection SeriesCollection3 { get; set; }
        public string[] Labels { get; set; }

        public void BuildGraph1()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<int> { 10, 42, 39, 12, 31, 21, 15, 3, 12, 16, 0, 0 }
                }
            };

            Labels = new[] { "ЯНВ", "ФЕВ", "МАР", "АПР", "МАЙ", "ИЮН", "ИЮЛ", "АВГ", "СЕН", "ОКТ", "НОЯ", "ДЕК" };
        }
        public void BuildGraph2()
        {
            SeriesCollection2 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<int> { 2, 12, 6, 27, 23, 3, 8, 3, 7, 3, 10, 0 },
                }
            };

            Labels = new[] { "ЯНВ", "ФЕВ", "МАР", "АПР", "МАЙ", "ИЮН", "ИЮЛ", "АВГ", "СЕН", "ОКТ", "НОЯ", "ДЕК" };
        }

        public void BuildGraph3()
        {
            SeriesCollection3 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<int> { 3, 1, 2, 32, 2, 32, 3, 63, 33, 39, 70, 0 }
                }
            };

            Labels = new[] { "ЯНВ", "ФЕВ", "МАР", "АПР", "МАЙ", "ИЮН", "ИЮЛ", "АВГ", "СЕН", "ОКТ", "НОЯ", "ДЕК" };
        }
    }
}
