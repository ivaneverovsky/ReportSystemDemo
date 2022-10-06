using ReportSystemDemo.Data;
using ReportSystemDemo.Models;
using ReportSystemDemo.UIModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace ReportSystemDemo
{
    public partial class MainWindow : Window
    {
        OutputDataModel ODM = new OutputDataModel();
        DBConnection dbConnection = new DBConnection();
        Calculations calculations = new Calculations();

        Graph graph = new Graph();

        private string mainRequest = @"SELECT * FROM [dbo].Requests0310";

        //date for contracts
        private DateTime startDate;
        private DateTime endDate;

        //date for requests
        private DateTime yearDate;
        private DateTime QuarterSDate;
        private DateTime QuaterFDate;
        private DateTime MonthDate;

        //data for contracts
        private List<object> dbData = new List<object>();

        //data for requests
        private List<object> dbDataYear = new List<object>();
        private List<object> dbDataQuarter = new List<object>();
        private List<object> dbDataMonth = new List<object>();

        //values
        private List<string> Contracts = new List<string> { "АйЭмТи", "ИК Сибинтек (СН и УСИТО)", "РН-IaaS", "РН-Предикс", "ГеоПАК", "SAP HANA" };
        private List<string> Requests = new List<string> { "Месяц", "Квартал", "Год" };


        public MainWindow()
        {
            InitializeComponent();

            SetDate();

            reportDateMonth.Text = ODM.ReportDateMonth;
            reportDateYear.Text = ODM.ReportDateYear;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cleaning();
            CheckDate();
            Connect();
            CountRequests();
            CountContracts();
            CountGraphs();
        }

        //count values for graphs
        private void CountGraphs()
        {


            BuildGraphs();
        }

        //count requests
        private void CountRequests()
        {
            List<Requests> requests = new List<Requests>();

            Task<object>[] tasks = new Task<object>[3]
            {
                new Task<object>(() => calculations.RequestsBuilder(dbDataMonth, Requests[0])),
                new Task<object>(() => calculations.RequestsBuilder(dbDataQuarter, Requests[1])),
                new Task<object>(() => calculations.RequestsBuilder(dbDataYear, Requests[2]))
            };

            foreach (Task task in tasks)
                task.Start();

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Ошибка");
            }

            //collect for user
            requests = calculations.CollectRequests();

            for (int i = 0; i < requests.Count; i++)
                requestsListView.Items.Add(requests[i]);
        }

        //count contracts
        private void CountContracts()
        {
            List<Report> reports = new List<Report>();

            Task<Report>[] tasks = new Task<Report>[6]
            {
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[0])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[1])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[2])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[3])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[4])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[5]))
            };

            foreach (Task task in tasks)
                task.Start();

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Ошибка");
            }

            //collect for user
            reports = calculations.CollectReports();

            for (int i = 0; i < reports.Count; i++)
                reportListView.Items.Add(reports[i]);
        }

        //erase data
        private void Cleaning()
        {
            reportListView.Items.Clear();
            requestsListView.Items.Clear();

            calculations.ClearData();

            dbData.Clear();
            dbDataMonth.Clear();
            dbDataQuarter.Clear();
            dbDataYear.Clear();

        }

        //db request
        private async void Connect()
        {
            await dbConnection.CreateConnection();

            dbData = await dbConnection.SendCommandRequest(mainRequest + " WHERE CAST([Дата создания] AS date) >= '" + startDate + "'" + " AND CAST([Дата создания] AS date) <= '" + endDate + "'");

            dbDataMonth = await dbConnection.SendCommandRequest(mainRequest + " WHERE CAST([Дата создания] AS date) >= '" + MonthDate + "'");
            dbDataQuarter = await dbConnection.SendCommandRequest(mainRequest + " WHERE CAST([Дата создания] AS date) >= '" + QuarterSDate + "'" + " AND CAST([Дата создания] AS date) <= '" + QuaterFDate + "'");
            dbDataYear = await dbConnection.SendCommandRequest(mainRequest + " WHERE CAST([Дата создания] AS date) >= '" + yearDate + "'");

            dbConnection.CloseConnection();
        }

        //count values for Graphs
        private void BuildGraphs()
        {
            graph.BuildGraphs();

            graphLowGrade.Series = graph.SeriesCollectionLowGrade;
            graphLowGrade.AxisX[0].Labels = graph.Labels;
            graphLowGrade.AxisY[0].LabelFormatter = graph.Formatter;

            graphRestart.Series = graph.SeriesCollectionRestart;
            graphRestart.AxisX[0].Labels = graph.Labels;
            graphRestart.AxisY[0].LabelFormatter = graph.Formatter;

            graphCrisis.Series = graph.SeriesCollectionCrisis;
            graphCrisis.AxisX[0].Labels = graph.Labels;
            graphCrisis.AxisY[0].LabelFormatter = graph.Formatter;

        }

        //set date for Year, Quarter and Month
        private void SetDate()
        {
            yearDate = new DateTime(DateTime.Now.Year, 1, 1);
            MonthDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3)
            {
                QuarterSDate = new DateTime(DateTime.Now.Year, 1, 1);
                QuaterFDate = new DateTime(DateTime.Now.Year, 3, 31);
            }
            else if (DateTime.Now.Month >= 4 && DateTime.Now.Month <= 6)
            {
                QuarterSDate = new DateTime(DateTime.Now.Year, 4, 1);
                QuaterFDate = new DateTime(DateTime.Now.Year, 6, 30);
            }
            else if (DateTime.Now.Month >= 7 && DateTime.Now.Month <= 9)
            {
                QuarterSDate = new DateTime(DateTime.Now.Year, 7, 1);
                QuaterFDate = new DateTime(DateTime.Now.Year, 9, 30);
            }
            else
            {
                QuarterSDate = new DateTime(DateTime.Now.Year, 10, 1);
                QuaterFDate = new DateTime(DateTime.Now.Year, 12, 31);
            }
        }

        //check user input
        private void CheckDate()
        {
            try
            {
                startDate = sDate.SelectedDate.Value;
                endDate = fDate.SelectedDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59); //sets the end of a date as a datepicker detects date from day start (12:00 AM)

                if (startDate > endDate)
                {
                    DateTime misDate = startDate;
                    startDate = endDate;
                    endDate = misDate;

                    //MessageBox.Show("Начальная дата должна быть меньше конечной даты!\nПрограмма продолжит работу.\nУказанный диапазон принят.", "Внимание");

                    sDate.SelectedDate = startDate;
                    fDate.SelectedDate = endDate;
                }
            }
            catch
            {
                endDate = DateTime.Now.Date; //program sets the start of a day
                startDate = endDate.Date.AddDays(-7);
                endDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59); //we set the end of a day

                MessageBox.Show("Введите дату!\nПрограмма продолжит работу.\nОтчет будет составлен за период:\nс " + startDate + "\nпо " + endDate, "Внимание");

                sDate.SelectedDate = startDate;
                fDate.SelectedDate = endDate;
            }
        }
    }
}
