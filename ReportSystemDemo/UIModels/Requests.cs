using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystemDemo.UIModels
{
    internal class Requests
    {
        public int GetMonth { get; set; }
        public int GetQuarter { get; set; }
        public int GetYear { get; set; }
        public int ClosedMonth { get; set; }
        public int ClosedQuarter { get; set; }
        public int ClosedYear { get; set; }
        public int SLAMonth { get; set; }
        public int SLAQuarter { get; set; }
        public int SLAYear { get; set; }
        public int CriticalMonth { get; set; }
        public int CriticalQuarter { get; set; }
        public int CriticalYear { get; set; }

        public Requests(int getMonth, int getQuarter, int getYear, int closedMonth, int closedQuarter,
            int closedYear, int sLAMonth, int sLAQuarter, int sLAYear, int criticalMonth,
            int criticalQuarter, int criticalYear)
        {
            GetMonth = getMonth;
            GetQuarter = getQuarter;
            GetYear = getYear;
            ClosedMonth = closedMonth;
            ClosedQuarter = closedQuarter;
            ClosedYear = closedYear;
            SLAMonth = sLAMonth;
            SLAQuarter = sLAQuarter;
            SLAYear = sLAYear;
            CriticalMonth = criticalMonth;
            CriticalQuarter = criticalQuarter;
            CriticalYear = criticalYear;
        }
    }
}
