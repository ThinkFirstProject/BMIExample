using Specflow_UI_MSCUI.Map.BMIStartMapClasses;
using Specflow_UI_MSCUI.Map.NewPersonMapClasses;
using Specflow_UI_MSCUI.Map.Personview;
using UI_MSCUI.Maps.MeasurementMapClasses;

namespace Specflow_UI_MSCUI.Map
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
