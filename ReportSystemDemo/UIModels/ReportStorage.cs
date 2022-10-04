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
        private List<Requests> _requests = new List<Requests>();

        public List<Report> Reports { get { return _reports; } }
        public List<Requests> Requests { get { return _requests; } }


        public void AddReport(Report report)
        {
            _reports.Add(report);
        }
        public void AddRequest(Requests request)
        {
            _requests.Add(request);
        }

        public void ClearLists()
        {
            _reports.Clear();
            _requests.Clear();
        }

        

        
    }
}
