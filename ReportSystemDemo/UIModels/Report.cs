namespace ReportSystemDemo.UIModels
{
    internal class Report
    {
        public bool Status { get; set; }
        public string ContractName { get; set; }
        public int ResortAmount { get; set; }
        public int Critical { get; set; }
        public double TargetSLA { get; } = 89.0;
        public double ActualSLA { get; set; }
        public int Requests { get; set; }
        public int Incidents { get; set; }
        public double Percent { get; set; }
        public double Five { get; set; }
        public double Four { get; set; }
        public double Three { get; set; }
        public double Two { get; set; }
        public double NoMark { get; set; }
        public double Restart { get; set; }

        public Report(bool status, string contractName, int resortAmount, int critical, double targetSLA,
            double actualSLA, int requests, int incidents, double percent, double five, double four,
            double three, double two, double noMark, double restart)
        {
            Status = status;
            ContractName = contractName;
            ResortAmount = resortAmount;
            Critical = critical;
            TargetSLA = targetSLA;
            ActualSLA = actualSLA;
            Requests = requests;
            Incidents = incidents;
            Percent = percent;
            Five = five;
            Four = four;
            Three = three;
            Two = two;
            NoMark = noMark;
            Restart = restart;
        }
    }
}
