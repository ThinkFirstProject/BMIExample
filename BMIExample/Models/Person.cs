using System;
using System.Collections.Generic;
using System.Linq;
using BMIExample.Models.Containers;
using BMIExample.Models.Def;

namespace BMIExample.Models
{
    public class Person: Identifiable
    {
        private String _socialSecurityNumber;
        private DateTime _birthDate;
        private PersonDef.Gender _gender;
        private List<Measurement> _measurements;
        private Boolean _isMeasurementsSorted;

        public Person()
        {
            socialSecurityNumber = "";
            birthDate = new DateTime();
            _measurements = new List<Measurement>();
            _isMeasurementsSorted = true;
        }

        public Person(String socialSecurityNumber, DateTime birthDate, PersonDef.Gender gender, Measurement firstMeasurement)
        {
            _measurements = new List<Measurement>();
            this.socialSecurityNumber = socialSecurityNumber;
            _birthDate = birthDate;
            _gender = gender;
            addMeasurement(firstMeasurement);
        }
        
        public string socialSecurityNumber
        {
            get
            {
                return _socialSecurityNumber;
            }
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentException("Social security number cannot be null");
                }

                _socialSecurityNumber = value;
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
                    throw new ArgumentException("BirthDate cannot be null");
                }

                _birthDate = value;
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

            _isMeasurementsSorted = false;

            _measurements.Add(measurement);
        }

        public void removeMeasurement(Measurement measurement) 
		{
            if (measurement == null)
            {
                throw new ArgumentException("Measurement cannot be null");
            }

            if (_measurements.Exists(e => e.date.Equals(measurement.date)))
            {
                _measurements.Remove(_measurements.Find(e => e.date.Equals(measurement.date)));
            }
            else
            {
                throw new ArgumentException("Measurement with the targeted date doesn't exist");   
            }

		}

        private Measurement getLastMeasurement()
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
            double weightInKilo = (double)getWeight() / 1000;
            double lengthInMeter = (double)getLength() / 100;
            double squareLength = lengthInMeter * lengthInMeter;

            return Math.Round(weightInKilo / squareLength, 2);
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
    }
}
