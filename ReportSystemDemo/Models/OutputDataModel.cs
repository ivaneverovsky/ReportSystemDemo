using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystemDemo.Models
{
    internal class OutputDataModel
    {

        public string ReportDateMonth { get { return ReturnMonth(); } }
        public string ReportDateYear { get { return DateTime.Now.Year.ToString() + " года"; } }

        //OPTIONAL: user input
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }

        private static List<string> MonthList = new List<string>() {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь"
            , "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};

        static string ReturnMonth()
        {
            DateTime time = DateTime.Now;
            string month = MonthList[time.Month - 1];

            return month;
        }
    }
}
