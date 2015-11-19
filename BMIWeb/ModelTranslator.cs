using System;
using BMI.Def;
using BMIWeb.DAL;

namespace BMIWeb
{
    public class ModelTranslator
    {
        public static Measurement convertMeasurementToCTXMeasurement(String socialSecurityNumber, BMI.Containers.Measurement measurement)
        {
            if (measurement != null && socialSecurityNumber != null)
            {
                return new Measurement
                {
                    SocialSecurityNumber = socialSecurityNumber,
                    Length = measurement.length,
                    Weight = measurement.weight,
                    Date = measurement.date
                };
            }

            return null;
        }

        public static BMI.Containers.Measurement convertCTXMeasurementToMeasurement(Measurement measurement)
        {
            if (measurement != null)
            {
                return new BMI.Containers.Measurement(measurement.Length, measurement.Weight, measurement.Date);
            }

            return null;
        }

        public static Person convertPersonToCTXPerson(BMI.Person person)
        {
            if (person != null)
            {
                Person retVal = new Person
                {
                    SocialSecurityNumber = person.socialSecurityNumber,
                    BirthDate = person.birthDate,
                    Gender = person.gender.ToString()
                };

                foreach (BMI.Containers.Measurement measurement in person.measurements)
                {
                    retVal.Measurements.Add(convertMeasurementToCTXMeasurement(person.socialSecurityNumber, measurement));
                }

                return retVal;

            }

            return null;
        }

        public static BMI.Person convertCTXPersonToPerson(Person person)
        {
            if (person != null)
            {
                BMI.Person retVal = new BMI.Person
                {
                    socialSecurityNumber = person.SocialSecurityNumber,
                    birthDate = person.BirthDate,
                    gender = (PersonDef.Gender)Enum.Parse(typeof(PersonDef.Gender), person.Gender)
                };

                foreach (Measurement measurement in person.Measurements)
                {
                    retVal.measurements.Add(convertCTXMeasurementToMeasurement(measurement));
                }

                return retVal;

            }

            return null;
        }   
    }
}
