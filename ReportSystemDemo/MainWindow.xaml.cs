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

        private string mainRequest = @"SELECT * FROM [dbo].Requests";

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

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                for (int j = 0; j < guf.Length; j++)
                {
                    var a = guf[j];
                    MessageBox.Show(a.ToString());
                }
            }


            dbConnection.CloseConnection();



            //var SIBINTEK = await dbConnection.SendCommandGetValue("SELECT COUNT (*) FROM [dbo].Requests WHERE ([Сервисный контракт] = N'ЭКСПЕРТЕК ИБС' " +
            //"OR[Сервисный контракт] = N'ЛВ Сфера' OR[Сервисный контракт] = N'РБС' OR[Сервисный контракт] = N'Снегирь Софт' OR[Сервисный контракт] = N'ИК Сибинтек ДИТиАВП СН' " +
            //"OR[Сервисный контракт] = N'ИК Сибинтек УСИТО' OR[Сервисный контракт] = N'ИК Сибинтек СН' OR[Сервисный контракт] = N'Сибинтек Софт') " +
            //"AND CAST([Дата создания] AS date) > '" + dateY + "-" + dateM + "-01'");



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


            MessageBox.Show("i'm done", "So");
        }
    }
}
