using ReportSystemDemo.Data;
using ReportSystemDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ReportSystemDemo
{
    public partial class MainWindow : Window
    {
        OutputDataModel ODM = new OutputDataModel();
        DBConnection dbConnection = new DBConnection();

        private string mainRequest = @"SELECT * FROM [dbo].Requests0310";

        public MainWindow()
        {
            InitializeComponent();


            reportDateMonth.Text = ODM.ReportDateMonth;
            reportDateYear.Text = ODM.ReportDateYear;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await dbConnection.CreateConnection();

            List<object> dbData = await dbConnection.SendCommandRequest(mainRequest);

            dbConnection.CloseConnection();

            //make Tasks in other class
            //get dbData
            //make requests 


            //amount of requests
            int counter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                try
                {
                    DateTime a = (DateTime)guf[2];

                    if (a.Month == DateTime.Now.Month && a.Year == DateTime.Now.Year)
                        counter++;
                }
                catch
                {
                    continue;
                }
            }
            MessageBox.Show("Requests created: " + counter.ToString());

            //amount of closed requests
            int counter2 = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                try
                {
                    DateTime a = (DateTime)guf[2];
                    string status = (string)guf[7];

                    if (status == "Закрыто" && a.Month == DateTime.Now.Month && a.Year == DateTime.Now.Year)
                        counter2++;
                }
                catch
                {
                    continue;
                }
            }
            MessageBox.Show("Requests closed: " + counter2.ToString());

            //count SLA
            int counter3 = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                try
                {
                    DateTime a = (DateTime)guf[2];

                    if (guf[13].ToString() != "" && a.Month == DateTime.Now.Month && a.Year == DateTime.Now.Year)
                        counter3++;
                }
                catch
                {
                    continue;
                }
            }
            double SLA = (1 - counter3 / (double)counter) * 100;

            MessageBox.Show("SLA: " + Math.Round(SLA, 2).ToString() + "%");

            //Task[] tasks = new Task[4]
            //{
            //    new Task(() =>  dbConnection.SendCommand("SELECT COUNT (Номер) FROM [dbo].Requests WHERE SUBSTRING([Номер],3,6) = SUBSTRING('О-240038',3,6)")),
            //    new Task(() =>  dbConnection.SendCommand("SELECT COUNT (*) FROM [dbo].Requests")),
            //    new Task(() =>  dbConnection.SendCommand("SELECT COUNT (*) FROM [dbo].Requests WHERE [Оценка пользователя] = 5")),
            //    new Task(() =>  dbConnection.SendCommandRequest("SELECT * FROM [dbo].Requests"))
            //};

            //foreach (Task task in tasks)
            //    task.Start();


            //try
            //{
            //    //wait threads
            //    Task.WaitAll(tasks);
            //}
            //catch (AggregateException ae)
            //{
            //    MessageBox.Show(ae.Message, "Error");
            //}
        }
    }
}
