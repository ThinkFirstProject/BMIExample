namespace UI_Ranorex.Maps
{
    public static class BMIUIMap
    {
        private static BMIStartMap _BMIStartMap;
        private static MeasurementMap _measurementMap;
        private static NewPersonMap _newPersonMap;
        private static PersonViewMap _personViewMap;

        public static BMIStartMap BMIStartMap
        {
            get { return _BMIStartMap ?? (_BMIStartMap = new BMIStartMap()); }
        }

        public static MeasurementMap measurementMap
        {
            get { return _measurementMap ?? (_measurementMap = new MeasurementMap()); }
        }

        public static NewPersonMap newPersonMap
        {
            get { return _newPersonMap ?? (_newPersonMap = new NewPersonMap()); }
        }

        public static PersonViewMap personViewMap
        {
            get { return _personViewMap ?? (_personViewMap = new PersonViewMap()); }
        }
    }
}
