namespace ReportSystemDemo.UIModels
{
    internal class Requests
    {
        public string RequestForm { get; set; }
        public int GetMonth { get; set; }
        public int GetQuarter { get; set; }
        public int GetYear { get; set; }
        

        public Requests(string requestForm, int getMonth, int getQuarter, int getYear)
        {
            RequestForm = requestForm;
            GetMonth = getMonth;
            GetQuarter = getQuarter;
            GetYear = getYear;
        }
    }
}
