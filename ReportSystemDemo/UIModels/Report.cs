using System.Windows.Media;

namespace ReportSystemDemo.UIModels
{
    internal class Report
    {
        public bool Status { get; set; }
        public string Color { get; set; }
        public string ContractName { get; set; }
        public int ReportAmount { get; set; }
        public int Critical { get; set; }
        public double TargetSLA { get; set; }
        public double ActualSLA { get; set; }
        public int Requests { get; set; }
        public int Incidents { get; set; }
        public double Five { get; set; }
        public double Four { get; set; }
        public double Three { get; set; }
        public double Two { get; set; }
        public double NoMark { get; set; }
        public double Restart { get; set; }

        public Report(bool status, string color, string contractName, int reportAmount, int critical, double targetSLA,
            double actualSLA, int requests, int incidents, double five, double four,
            double three, double two, double noMark, double restart)
        {
            Status = status;
            Color = color;
            ContractName = contractName;
            ReportAmount = reportAmount;
            Critical = critical;
            TargetSLA = targetSLA;
            ActualSLA = actualSLA;
            Requests = requests;
            Incidents = incidents;
            Five = five;
            Four = four;
            Three = three;
            Two = two;
            NoMark = noMark;
            Restart = restart;
        }
    }
}
