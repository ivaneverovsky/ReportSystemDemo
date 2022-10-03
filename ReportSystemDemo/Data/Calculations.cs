using System;
using System.Collections.Generic;

namespace ReportSystemDemo.Data
{
    internal class Calculations
    {
        //number of requests
        public int SumRequests(List<object> dbData)
        {
            int counter = dbData.Count;

            return counter;
        }

        //number of closed requests
        public int SumClosedRequests(List<object> dbData)
        {
            int counter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                if (guf[7].ToString() == "Закрыто")
                    counter++;
            }

            return counter;
        }

        //Count SLA percentage
        public double SumSLA(List<object> dbData, int sumRequests)
        {
            int counter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                if (guf[13].ToString() != "")
                    counter++;
            }
            
            double SLA = (1 - counter / (double)sumRequests) * 100;

            return Math.Round(SLA, 2);
        }

        //count crisis incidents
        public int SumCrisis(List<object> dbData)
        {
            int counter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                if (guf[6].ToString() == "True")
                    counter++;
            }

            return counter;
        }
    }
}
