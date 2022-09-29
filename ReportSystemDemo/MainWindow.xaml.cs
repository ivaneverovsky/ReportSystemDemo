using ReportSystemDemo.Data;
using ReportSystemDemo.Models;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace ReportSystemDemo
{
    public partial class MainWindow : Window
    {
        OutputDataModel ODM = new OutputDataModel();
        DBConnection dbConnection = new DBConnection();
        
        private object request1 = "SELECT COUNT (Номер) FROM [dbo].Requests WHERE SUBSTRING([Номер],3,6) = SUBSTRING('О-240038',3,6)";
        private object request2 = "SELECT COUNT (*) FROM [dbo].Requests";
        private object request3 = "SELECT COUNT (*) FROM [dbo].Requests WHERE [Оценка пользователя] = 5";

        public MainWindow()
        {
            InitializeComponent();


            reportDateMonth.Text = ODM.ReportDateMonth;
            reportDateYear.Text = ODM.ReportDateYear;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbConnection.CreateConnection();

            Thread thread1 = new Thread(dbConnection.SendCommand);
            thread1.Start(request1);

            Thread thread2 = new Thread(dbConnection.SendCommand);
            thread2.Start(request2);

            Thread thread3 = new Thread(dbConnection.SendCommand);
            thread3.Start(request3);



            //dbConnection.SendCommand(request1);
            //dbConnection.SendCommand(request2);
            //dbConnection.SendCommand(request3);

            //dbConnection.CloseConnection();
        }
    }
}
