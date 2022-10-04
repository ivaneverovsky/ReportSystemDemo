using ReportSystemDemo.Data;
using ReportSystemDemo.Models;
using ReportSystemDemo.UIModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace ReportSystemDemo
{
    public partial class MainWindow : Window
    {
        OutputDataModel ODM = new OutputDataModel();
        DBConnection dbConnection = new DBConnection();
        Calculations calculations = new Calculations();

        Stopwatch sw = new Stopwatch();

        private string mainRequest = @"SELECT * FROM [dbo].Requests0310 WHERE CAST([Дата создания] AS date) >= '";

        private DateTime startDate;
        private DateTime endDate;

        private List<object> dbData = new List<object>();
        private List<string> Contracts = new List<string> { "АйЭмТи", "ИК Сибинтек (СН и УСИТО)", "РН-IaaS", "РН-Предикс", "ГеоПАК", "SAP HANA" };

        public MainWindow()
        {
            InitializeComponent();


            reportDateMonth.Text = ODM.ReportDateMonth;
            reportDateYear.Text = ODM.ReportDateYear;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cleaning();
            CheckDate();

            sw.Start();

            Connect();
            CountValues();
            CountContracts();
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

                    MessageBox.Show("Начальная дата должна быть меньше конечной даты!\nПрограмма продолжит работу.\nУказанный диапазон принят.", "Внимание");

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
            }
        }

        //db request
        private async void Connect()
        {
            await dbConnection.CreateConnection();

            dbData = await dbConnection.SendCommandRequest(mainRequest + startDate + "'" + " AND CAST([Дата создания] AS date) <= '" + endDate + "'");

            dbConnection.CloseConnection();
        }

        //count values
        private void CountValues()
        {
            Task<object>[] tasks = new Task<object>[3]
            {
                new Task<object>(() => calculations.SumRequests(dbData)),
                new Task<object>(() => calculations.SumClosedRequests(dbData)),
                new Task<object>(() => calculations.SumCrisis(dbData)),
            };

            foreach (Task task in tasks)
                task.Start();

            Task<double> sumSLA = tasks[0].ContinueWith(t => calculations.SumSLA(dbData, (int)tasks[0].Result));

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Ошибка");
            }
        }

        //count contracts
        private Task<Report>[] CountContracts()
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

            sw.Stop();
            MessageBox.Show("Time elapsed: " + sw.Elapsed);
            sw.Reset();

            return tasks;
        }

        private void Cleaning()
        {
            reportListView.Items.Clear();
            calculations.ClearReports();
        }
    }
}
