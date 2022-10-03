namespace ReportSystemDemo.UIModels
{
    internal class ServiceQualityDynamics
    {
        public bool Jan { get; set; }
        public bool Feb { get; set; }
        public bool Mar { get; set; }
        public bool Apr { get; set; }
        public bool May { get; set; }
        public bool Jun { get; set; }
        public bool Jul { get; set; }
        public bool Aug { get; set; }
        public bool Sep { get; set; }
        public bool Oct { get; set; }
        public bool Nov { get; set; }
        public bool Dec { get; set; }

        public ServiceQualityDynamics(bool jan, bool feb, bool mar, bool apr, bool may, bool jun
            , bool jul, bool aug, bool sep, bool oct, bool nov, bool dec)
        {
            Jan = jan;
            Feb = feb;
            Mar = mar;
            Apr = apr;
            May = may;
            Jun = jun;
            Jul = jul;
            Aug = aug;
            Sep = sep;
            Oct = oct;
            Nov = nov;
            Dec = dec;
        }
    }
}
