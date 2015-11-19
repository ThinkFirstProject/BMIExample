using System;
using BMIExample.Models.Containers;


namespace BMITestFitNesse
{
    /*
    public class ChangeLengthParameters : fit.ColumnFixture
    {
        private int _weight;
        private int _length;
        private int _newLength;
        private DateTime _date;

        public String Description;

        private Measurement _measurement;

        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        public int NewLength
        {
            get
            {
                return _newLength;
            }
            set
            {
                _newLength = value;
            }
        }

        public String Date
        {
            get
            {
                return _date.Day + "-" + _date.Month + "-" + _date.Year;
            }
            set
            {
                _date = DateTime.Parse(value);
            }
        }

        public String ChangeLength()
        {
            try
            {
                _measurement = new Measurement();

                _measurement.length = _length;
                _measurement.weight = _weight;
                _measurement.date = _date;

                _measurement.length = _newLength;

                return _measurement.length.ToString();
            }
            catch (Exception ex)
            {
                return "Exception";
            }
        }
    } */

    public class CreateObjectWithValidLengthParameters : fit.ColumnFixture
    {
        private int _weight;
        private int _length;
        private DateTime _date;

        public String Description;

        private Measurement _measurement;

        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }
        
        public String Date
        {
            get
            {
                return _date.Day + "-" + _date.Month + "-" + _date.Year;
            }
            set
            {
                _date = DateTime.Parse(value);
            }
        }

        public String CreateObject()
        {
            _measurement = new Measurement(_length, _weight, _date);

            if (_measurement.length != _length)
            {
                return "No";
            }

            if (_measurement.weight != _weight)
            {
                return "No";
            }

            if (_measurement.date != _date)
            {
                return "No";
            }

            return "Yes";
        }
    }

    public class CreateObjectWithInValidLengthParameters : fit.ColumnFixture
    {
        private int _weight;
        private int _length;
        private DateTime _date;

        public String Description;

        private Measurement _measurement;

        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        public String Date
        {
            get
            {
                return _date.Day + "-" + _date.Month + "-" + _date.Year;
            }
            set
            {
                _date = DateTime.Parse(value);
            }
        }

        public String CreateObjectWithError()
        {
            try
            {
                _measurement = new Measurement(_length, _weight, _date);

                return "No";
            }
            catch (ArgumentException)
            {

                return "Yes";
            }
        }
    }
}
