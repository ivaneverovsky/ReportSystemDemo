﻿namespace ReportSystemDemo.UIModels
{
    internal class Requests
    {
        public int GetRequests { get; set; }
        public int ClosedRequests { get; set; }
        public double TotalSLA { get; set; }
        public int CrisisCount { get; set; }
        public string DateType { get; set; }

        public Requests(int getRequests, int closedRequests, double totalSLA, int crisisCount, string dateType)
        {
            GetRequests = getRequests;
            ClosedRequests = closedRequests;
            TotalSLA = totalSLA;
            CrisisCount = crisisCount;
            DateType = dateType;
        }
    }
}
