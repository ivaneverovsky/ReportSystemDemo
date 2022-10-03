using ReportSystemDemo.Data;
using ReportSystemDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ReportSystemDemo
{
    public partial class MainWindow : Window
    {
        OutputDataModel ODM = new OutputDataModel();
        DBConnection dbConnection = new DBConnection();
        Calculations calculations = new Calculations();

        private string mainRequest = @"SELECT * FROM [dbo].Requests0310 WHERE CAST([Дата создания] AS date) >= '";

        private DateTime startDate;
        private DateTime endDate;

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

            await dbConnection.CreateConnection();

            List<object> dbData = await dbConnection.SendCommandRequest(mainRequest + startDate + "'" + " AND CAST([Дата создания] AS date) <= '" + endDate + "'");

            dbConnection.CloseConnection();

            //count values
            Task<object>[] tasks = new Task<object>[3]
            {
                new Task<object>(() => calculations.SumRequests(dbData)),
                new Task<object>(() => calculations.SumClosedRequests(dbData)),
                new Task<object>(() => calculations.SumCrisis(dbData))
            };

            foreach (Task task in tasks)
                task.Start();

            Task<double> sumSLA = tasks[0].ContinueWith(t => calculations.SumSLA(dbData, (int)tasks[0].Result));


            try
            {
                Task.WaitAll(tasks);
                MessageBox.Show(sumSLA.Result.ToString());
                MessageBox.Show(tasks[2].Result.ToString());
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Ошибка");
            }
        }
    }
}
