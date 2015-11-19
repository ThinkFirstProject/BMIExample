using System;

namespace BMIExample.Models.Containers
{
    public class Measurement :Identifiable, IComparable
    {
        private DateTime _date;
        private int _length;
        private int _weight;

        public Measurement()
        {
            _length = 0;
            _weight = 0;
            _date = DateTime.Now;
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
                if (value < Properties.Settings.Default.MinLength || value > Properties.Settings.Default.MaxLength)
                {
                    throw new ArgumentException("Not a valid length");
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
                if (value < Properties.Settings.Default.MinWeight || value > Properties.Settings.Default.MaxWeight)
                {
                    throw new ArgumentException("Not a valid weight");
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
    }
}
