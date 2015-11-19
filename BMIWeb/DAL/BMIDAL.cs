using System;
using System.Collections.Generic;
using System.Linq;

namespace BMIWeb.DAL
{
    public class BMIDAL: IBMIDAL
    {
        private readonly BMIDBContext _ctxBMI;
        
        public BMIDAL()
        {
            _ctxBMI = new BMIDBContext();
        }
       
        public BMI.Person getPerson(string socialSecurityNumber)
        {
            if (String.IsNullOrEmpty(socialSecurityNumber))
            {
                throw new Exception();   
            }

            if (_ctxBMI.People.Count(e => e.SocialSecurityNumber == socialSecurityNumber) == 1)
            {
                BMI.Person personObj =
                    ModelTranslator.convertCTXPersonToPerson(
                        _ctxBMI.People.First(e => e.SocialSecurityNumber == socialSecurityNumber));

                if (personObj != null)
                {
                    return personObj;
                }
            }

            return null;

        }

        public bool addPerson(BMI.Person newPerson)
        {
            if (_ctxBMI.People.Count(e => e.SocialSecurityNumber == newPerson.socialSecurityNumber) == 0)
            {
                Person personObj = ModelTranslator.convertPersonToCTXPerson(newPerson);

                if (personObj != null)
                {
                    _ctxBMI.People.Add(personObj);
                    _ctxBMI.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public bool addMeasurement(string socialSecurityNumber, BMI.Containers.Measurement newMeasurement)
        {
            if (String.IsNullOrEmpty(socialSecurityNumber) || newMeasurement == null)
            {
                throw new Exception();
            }

            if (_ctxBMI.People.Count(e => e.SocialSecurityNumber == socialSecurityNumber) != 0)
            {
                Measurement measurementObj = ModelTranslator.convertMeasurementToCTXMeasurement(socialSecurityNumber, newMeasurement);

                if (measurementObj != null)
                {
                    _ctxBMI.Measurements.Add(measurementObj);
                    _ctxBMI.SaveChanges();

                    return true;
                }
            }

            return false;
        }
        
        public List<string> getSocialSecurityNumberList()
        {
            return _ctxBMI.People.Select(e => e.SocialSecurityNumber).ToList();
        }
    }
}