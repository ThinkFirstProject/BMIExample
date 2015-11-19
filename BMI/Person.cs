using System;
using System.Collections.Generic;
using System.Linq;
using BMI.Containers;
using BMI.Def;

namespace BMI
{
    public class Person: Identifiable
    {
        private String _socialSecurityNumber;
        private DateTime _birthDate;
        private PersonDef.Gender _gender;
        private readonly List<Measurement> _measurements;
        private Boolean _isMeasurementsSorted;
        private Boolean _isChanged;

        public Person()
        {
            _socialSecurityNumber = "";
            _birthDate = new DateTime();
            _measurements = new List<Measurement>();
            _isMeasurementsSorted = true;
            _isChanged = true;
        }

        public Person(String socialSecurityNumber, DateTime birthDate, PersonDef.Gender gender, Measurement firstMeasurement)
        {
            if (socialSecurityNumber == null)
            {
                throw new ArgumentException("Invalid social security number");   
            }

            if (firstMeasurement == null)
            {
                throw new ArgumentException("Invalid first measurement");
            }

            _measurements = new List<Measurement>();
            this.socialSecurityNumber = socialSecurityNumber;
            _birthDate = birthDate;
            _gender = gender;
            addMeasurement(firstMeasurement);
            _isChanged = true;
        }
        
        public string socialSecurityNumber
        {
            get
            {
                return _socialSecurityNumber;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid social security number");
                }

                _socialSecurityNumber = value;
                _isChanged = true;
            }
        }

        public DateTime birthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (_birthDate == null)
                {
                    throw new ArgumentException("Invalid birthdate");
                }

                _birthDate = value;
                _isChanged = true;
            }
        }

        public Boolean isChanged
        {
            get
            {
                return _isChanged;
            }
        }

        public PersonDef.Gender gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                _isChanged = true;
            }
        }

        public List<Measurement> measurements
        {
            get
            {
                if (!_isMeasurementsSorted)
                {
                    _measurements.Sort();
                    _isMeasurementsSorted = true;
                }

                return _measurements;
            }
        }

        public void addMeasurement(Measurement measurement)
        {
            if (measurement == null)
            {
                throw new ArgumentException("Measurement cannot be null");
            }

            if (_measurements.Exists(e => e.date.Day == measurement.date.Day && 
                                          e.date.Month == measurement.date.Month &&
                                          e.date.Year == measurement.date.Year))
            {
                throw new ArgumentException("A measurement for this moment is already registered");   
            }

            _isMeasurementsSorted = false;

            _measurements.Add(measurement);
            _isChanged = true;
        }

        public void removeLastMeasurement()
        {
            Measurement lastMeasurement = getLastMeasurement();

            if (lastMeasurement != null)
            {
                _measurements.Remove(_measurements.Find(e => e.date.Equals(lastMeasurement.date)));
                _isChanged = true;
            }
        }

        public Measurement getLastMeasurement()
        {
            if (!_isMeasurementsSorted)
            {
                _measurements.Sort();
                _isMeasurementsSorted = true;
            }

            return _measurements.Last();
        }

        public double getBMI()
        {
            return getLastMeasurement().getBMI();
        }

        public Boolean equals(Person person)
        {
           
            if (person != null && _socialSecurityNumber == person.socialSecurityNumber)
            {
                return true;
            }

            return false;
        }

        public String toString()
        {
            return "Person with number " + _socialSecurityNumber + ".";
        }

        public int getLength()
        {
            return getLastMeasurement().length;
        }

        public int getWeight()
        {
            return getLastMeasurement().weight;
        }

        public int getNumberOfMeasurements()
        {
            return measurements.Count();
        }

        public DateTime getLastMeasurementDate()
        {
            if (!_isMeasurementsSorted)
            {
                _measurements.Sort();
                _isMeasurementsSorted = true;
            }

            return getLastMeasurement().date;
        }

        public void changesSaved()
        {
            _isChanged = false;
        }
    }
}
