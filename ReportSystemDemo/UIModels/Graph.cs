using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace ReportSystemDemo.UIModels
{
    internal class Graph
    {
        public SeriesCollection SeriesCollectionLowGrade { get; set; }
        public SeriesCollection SeriesCollectionRestart { get; set; }
        public SeriesCollection SeriesCollectionCrisis { get; set; }
        public Func<double, string> Formatter { get; set; } = value => value.ToString() + "%";

        public List<string> Labels = new List<string> {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};

        public void BuildGraphs()
        {
            SeriesCollectionLowGrade = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Прошлый период",
                    Values = new ChartValues<double> { 0, 3, 1, 3, 5, 9, 10, 1, 5, 2, 5, 1 },
                    Fill = Brushes.Gray,
                },

                new LineSeries
                {
                    Title = "Факт",
                    Values = new ChartValues<double> { 1, 3, 2, 4, 8, 7, 15, 9, 4, 5, 2, 15 },
                    Fill = Brushes.Transparent,
                    StrokeThickness = 1,
                    LineSmoothness = 1,
                    Stroke = Brushes.DarkBlue
                }
            };

            SeriesCollectionRestart = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Прошлый период",
                    Values = new ChartValues<double> { 2, 12, 6, 27, 23, 3, 8, 3, 7, 3, 10, 60 },
                    Fill = Brushes.Gray,
                },

                new LineSeries
                {
                    Values = new ChartValues<double> { 1, 3, 2, 4, 8, 7, 15, 9, 4, 5, 2, 15 },
                    Fill = Brushes.Transparent,
                    StrokeThickness = 1,
                    Title = "Факт",
                    LineSmoothness = 1,
                    Stroke = Brushes.DarkBlue
                }
            };

            SeriesCollectionCrisis = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Прошлый период",
                    Values = new ChartValues<double> { 3, 1, 2, 32, 2, 32, 3, 63, 33, 39, 70, 30 },
                    Fill = Brushes.Gray,
                },

                new LineSeries
                {
                    Values = new ChartValues<double> { 1, 3, 2, 4, 8, 7, 15, 9, 4, 5, 2, 15 },
                    Fill = Brushes.Transparent,
                    StrokeThickness = 1,
                    Title = "Факт",
                    LineSmoothness = 1,
                    Stroke = Brushes.DarkBlue
                }
            };
        }
        //public void BuildGraphRestart()
        //{
           
        //}

        //public void BuildGraphCrisis()
        //{
            
        //}
    }
}
