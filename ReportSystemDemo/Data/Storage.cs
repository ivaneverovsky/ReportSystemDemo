using ReportSystemDemo.UIModels;
using System.Collections.Generic;

namespace ReportSystemDemo.Data
{
    internal class Storage
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
