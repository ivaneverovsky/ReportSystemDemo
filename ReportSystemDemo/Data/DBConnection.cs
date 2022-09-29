﻿using ReportSystemDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ReportSystemDemo.Data
{
    internal class DBConnection
    {
        readonly OleDbConnection connection = new OleDbConnection(@"Provider=MSOLEDBSQL.1;Initial Catalog=TestData;Data Source=(localdb)\MSSQLLocalDB;Trusted_Connection=Yes;Persist Security Info=False");

        public void CreateConnection()
        {
            try
            {
                connection.Open();
                //MessageBox.Show("db connected", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void SendCommand(string request)
        {
            OleDbCommand command = new OleDbCommand(request, connection);

            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader.GetValue(0);

                    MessageBox.Show(data.ToString(), "result");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
            //MessageBox.Show("db disconnected", "Success");
        }
    }
}
