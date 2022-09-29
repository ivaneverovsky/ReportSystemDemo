using ReportSystemDemo.Data;
using ReportSystemDemo.Models;
using System;
using System.Diagnostics;
using System.Threading;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ReportSystemDemo
{
    public partial class MainWindow : Window
    {
        OutputDataModel ODM = new OutputDataModel();
        DBConnection dbConnection = new DBConnection();

        public MainWindow()
        {
            InitializeComponent();


            reportDateMonth.Text = ODM.ReportDateMonth;
            reportDateYear.Text = ODM.ReportDateYear;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbConnection.CreateConnection();

            //get results from db
            Task[] tasks = new Task[3]
            {
                new Task(() => dbConnection.SendCommand("SELECT COUNT (Номер) FROM [dbo].Requests WHERE SUBSTRING([Номер],3,6) = SUBSTRING('О-240038',3,6)")),
                new Task(() => dbConnection.SendCommand("SELECT COUNT (*) FROM [dbo].Requests")),
                new Task(() => dbConnection.SendCommand("SELECT COUNT (*) FROM [dbo].Requests WHERE [Оценка пользователя] = 5"))
            };

            foreach (Task task in tasks)
                task.Start();

            try
            {
                //wait threads
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.Message, "Error");
            }
            

            

            dbConnection.CloseConnection();
        }
    }
}
