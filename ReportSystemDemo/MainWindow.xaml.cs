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

        List<string> Contracts = new List<string> { "АйЭмТи", "ИК Сибинтек (СН и УСИТО)", "РН-IaaS", "РН-Предикс", "ГеоПАК", "SAP HANA" };

        public MainWindow()
        {
            InitializeComponent();


            reportDateMonth.Text = ODM.ReportDateMonth;
            reportDateYear.Text = ODM.ReportDateYear;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
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
                    //continue method with rewrite data
                }
            }
            catch
            {
                endDate = DateTime.Now.Date; //program sets the start of a day
                startDate = endDate.Date.AddDays(-7);
                endDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59); //we set the end of a day

                MessageBox.Show("Введите дату!\nПрограмма продолжит работу.\nОтчет будет составлен за период:\nс " + startDate + "\nпо " + endDate, "Внимание");
                
                //continue method with rewrite data from exeption
            }

            sw.Start();


            await dbConnection.CreateConnection();

            List<object> dbData = await dbConnection.SendCommandRequest(mainRequest + startDate + "'" + " AND CAST([Дата создания] AS date) <= '" + endDate + "'");

            dbConnection.CloseConnection();

            //count values
            Task<object>[] tasks = new Task<object>[3]
            {
                new Task<object>(() => calculations.SumRequests(dbData)),
                new Task<object>(() => calculations.SumClosedRequests(dbData)),
                new Task<object>(() => calculations.SumCrisis(dbData)),
            };

            foreach (Task task in tasks)
                task.Start();

            Task<double> sumSLA = tasks[0].ContinueWith(t => calculations.SumSLA(dbData, (int)tasks[0].Result));

            //count contracts
            Task<Report>[] tasks2 = new Task<Report>[6]
            {
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[0])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[1])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[2])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[3])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[4])),
                new Task<Report>(() => calculations.ReportBuilder(dbData, Contracts[5]))
            };

            foreach (Task task in tasks2)
                task.Start();

            try
            {
                Task.WaitAll(tasks);

                Task.WaitAll(tasks2);
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Ошибка");
            }

            sw.Stop();
            MessageBox.Show("time elapsed: " + sw.Elapsed.ToString());

            foreach (var task in tasks2)
            {
                MessageBox.Show(task.Result.ContractName.ToString() + ": " + task.Result.Requests.ToString());
            }
           
            sw.Reset();
        }
    }
}
