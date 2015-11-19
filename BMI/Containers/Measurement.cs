using System;
using System.IO;
using BMI.Properties;

namespace BMI.Containers
{
    public class Measurement :Identifiable, IComparable
    {
        private DateTime _date;
        private int _length;
        private int _weight;

        public Measurement(int length, int weight)
        {
            this.length = length;
            this.weight = weight;
            this.date = DateTime.Now;
        }

        public Measurement(int length, int weight, DateTime date)
        {
            this.length = length;
            this.weight = weight;
            this.date = date;
        }

        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new InvalidDataException("Date should not be in the future");
                }

                _date = value;
            }
        }

        public int length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value < Settings.Default.MinLength || value > Settings.Default.MaxLength)
                {
                    throw new ArgumentException("Length should be between " + Settings.Default.MinLength + " and " + Settings.Default.MaxLength);
                }

                _length = value;
            }
        }

        public int weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value < Settings.Default.MinWeight || value > Settings.Default.MaxWeight)
                {
                    throw new ArgumentException("Weight should be between " + Settings.Default.MinWeight + " and " + Settings.Default.MaxWeight);
                }

                _weight = value;
            }
        }

        public int CompareTo(Object obj)
        {
            Measurement compareObj = (Measurement) obj;

            if (obj != null)
            {
                if (_date > compareObj.date)
                {
                    return 1;
                }
                
                if (_date < compareObj.date)
                {
                    return -1;
                }

                return 0;
            }

            return 1;
        }

        public Boolean equals(Object obj) 
        {
            if ((obj != null) && (obj.GetType() == typeof(Measurement))) 
            {
                Measurement measurement = (Measurement)obj;

			    if (_date.Equals(measurement.date))
			    {
			        return true;
			    }
		    }

		    return false;
	    }   

        public String toString()
        {
            return _length + "cm, " + _weight + "gr, " + _date;
        }

        public double getBMI()
        {
            double weightInKilo = Convert.ToDouble(_weight) / 1000;
            double lengthInMeter = Convert.ToDouble(_length) / 100;
            double squareLength = lengthInMeter * lengthInMeter;

            return Math.Round(weightInKilo / squareLength, 2);
        }
    }
}
