using LiveCharts;
using LiveCharts.Wpf;

namespace ReportSystemDemo.UIModels
{
    internal class GraphLowGrade
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
                    Values = new ChartValues<int> { 10, 42, 39, 12, 31, 21, 15, 3, 12, 16, 0, 0 }
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
