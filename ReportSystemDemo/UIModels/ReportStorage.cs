using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystemDemo.UIModels
{
    internal class ReportStorage
    {
        private List<Report> _reports = new List<Report>();
        public List<Report> Reports
        {
            get { return _reports; }
        }

        public void AddReport(Report report)
        {
            _reports.Add(report);
        }

        public void ClearReportList()
        {
            _reports.Clear();
        }
    }
}
