using System;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Specflow_Unit
{
    [Binding]
    public class PersonSteps
    {
        private const int NORMAL_WEIGHT = 75000;
        private const int NORMAL_LENGTH = 180;
        private const double BMI_REF = 23.15;
        private static readonly DateTime BIRTHDATE = new DateTime(2013, 10, 5);
        private static readonly DateTime OTHER_BIRTHDATE = new DateTime(2010, 10, 5);
        private static readonly DateTime DATE = new DateTime(2013, 10, 5);
        
        private String _socialSecurityNumber;
        private DateTime _birthDate;
        private PersonDef.Gender _gender;
        private Measurement _measurement;
        private Person _person;
        private Person _otherPerson;
        private double _BMI;
        private Boolean _result;

        [Given(@"valid personal data is provided")]
        public void GivenValidPersonalDataIsProvided(Table table)
        {
            _socialSecurityNumber = table.Rows[0]["Social security number"];
            _birthDate = DateTime.Parse(table.Rows[0]["Birthdate"]);
            _gender = (PersonDef.Gender)Enum.Parse(typeof (PersonDef.Gender), table.Rows[0]["Gender"]);
        }

        [Given(@"a valid measurement is provided")]
        public void GivenAValidMeasurementIsProvided(Table table)
        {
            _measurement = new Measurement(int.Parse(table.Rows[0]["Length"]), int.Parse(table.Rows[0]["Weight"]), DateTime.Parse(table.Rows[0]["Date"]));
        }

        [Given(@"a new valid measurement is provided")]
        public void GivenANewValidMeasurementIsProvided()
        {
            _measurement = new Measurement(NORMAL_LENGTH,NORMAL_WEIGHT, DATE);
        }
        
        [Given(@"a social security number (.*) is enterd which is invalid because (.*)")]
        public void GivenASocialSecurityNumberIsEnterdWhichIsInvalidBecause(String value, String reason)
        {
            _socialSecurityNumber = value;
        }

        [Given(@"a measurement which is null")]
        public void GivenAMeasurementWhichIsNull()
        {
            _measurement = null;
        }
        
        [Given(@"a valid person object is generated")]
        public void GivenAValidPersonObjectIsGenerated()
        {
            _person = new Person("10", BIRTHDATE, PersonDef.Gender.Male, new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, DATE));
        }
        
        [Given(@"a new valid measurement is added")]
        public void GivenANewValidMeasurementIsAdded()
        {
            _person.addMeasurement(new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, DateTime.Now));
            Assert.AreEqual(2, _person.measurements.Count);
        }

        [Given(@"a valid person object is generated with social security number (.*)")]
        public void GivenAValidPersonObjectIsGeneratedWithSocialSecurityNumber(String value)
        {
            _person = new Person(value, BIRTHDATE, PersonDef.Gender.Male, new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, DATE));
        }

        [Given(@"another valid person object is generated with social security number (.*), which is (.*)")]
        public void GivenAnotherValidPersonObjectIsGeneratedWithSocialSecurityNumberWhichIsALowerValue(String value, String circumstance)
        {
            _otherPerson = new Person(value, OTHER_BIRTHDATE, PersonDef.Gender.Female, new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, DATE));
        }
        
        [Then(@"the returned result should be (.*)")]
        public void ThenTheReturnedResultShouldBe(String result)
        {
            Assert.AreEqual(Boolean.Parse(result), _result);
        }
        
        [When(@"i try to create a person object")]
        public void WhenITryToCreateAPersonObject()
        {
            try
            {
                _person = new Person(_socialSecurityNumber, _birthDate, _gender, _measurement);
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [When(@"i try to change the social security number to the value (.*)")]
        public void WhenITryToChangeTheSocialSecurityNumberToTheValue(String value)
        {
            try
            {
                _socialSecurityNumber = value;
                _person.socialSecurityNumber = value;
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [When(@"i try to change the social security number to (.*) which is invalid because (.*)")]
        public void WhenITryToChangeTheSocialSecurityNumberToWhichIsInvalidBecause(String value, String reason)
        {
            try
            {
                switch (value)
                {
                    case "null":
                        _socialSecurityNumber = null;
                        _person.socialSecurityNumber = _socialSecurityNumber;
                        break;
                    case "empty":
                        _socialSecurityNumber = "";
                        _person.socialSecurityNumber = _socialSecurityNumber;
                        break;
                }
                
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [When(@"i try to change the birthdate to (.*)")]
        public void WhenITryToChangeTheBirthdateTo(String value)
        {
            _birthDate = DateTime.Parse(value);
            _person.birthDate = _birthDate;
        }

        [When(@"i try to change the gender to (.*)")]
        public void WhenITryToChangeTheGenderTo(String value)
        {
            _gender = (PersonDef.Gender) Enum.Parse(typeof (PersonDef.Gender), value);
            _person.gender = (PersonDef.Gender) Enum.Parse(typeof (PersonDef.Gender), value);
        }

        [When(@"i try to add the new measurement")]
        public void WhenITryToAddTheNewMeasurement()
        {
            try
            {
                _person.addMeasurement(_measurement);
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }
        
        [When(@"i try to remove the last measurement")]
        public void WhenITryToRemoveTheLastMeasurement()
        {
            try
            {
                _person.removeLastMeasurement();
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [When(@"i try to fetch the last measurement")]
        public void WhenITryToFetchTheLastMeasurement()
        {
            try
            {
                _measurement = _person.getLastMeasurement();
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [When(@"the objects are compared for equality")]
        public void WhenTheObjectsAreComparedForEquality()
        {
            _result = _person.equals(_otherPerson);
        }

        [When(@"i try to calculate the BMI of the person")]
        public void WhenITryToCalculateTheBMIOfThePerson()
        {
            try
            {
                _BMI = _person.getBMI();
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [Then(@"the object is created and contains the provided data")]
        public void ThenTheObjectIsCreatedAndContainsTheProvidedData()
        {
            Assert.AreEqual(_socialSecurityNumber, _person.socialSecurityNumber);
            Assert.AreEqual(_gender, _person.gender);
            Assert.AreEqual(_birthDate, _person.birthDate);
            Assert.AreEqual(_measurement, _person.measurements[0]);
        }
        
        [Then(@"the person object should contain the provided social security number")]
        public void ThenThePersonObjectShouldContainTheProvidedSocialSecurityNumber()
        {
            Assert.AreEqual(_socialSecurityNumber, _person.socialSecurityNumber);
        }

        [Then(@"the object should be updated with the new birthdate")]
        public void ThenTheObjectShouldBeUpdatedWithTheNewBirthdate()
        {
            Assert.AreEqual(_birthDate, _person.birthDate);
        }

        [Then(@"the object should be updated with the new gender")]
        public void ThenTheObjectShouldBeUpdatedWithTheNewGender()
        {
            Assert.AreEqual(_gender, _person.gender);
        }

        [Then(@"the object should contain the new measurement")]
        public void ThenTheObjectShouldContainTheNewMeasurement()
        {
            Assert.AreEqual(2, _person.measurements.Count);

            Assert.AreEqual(_measurement.length, _person.measurements[1].length);
            Assert.AreEqual(_measurement.weight, _person.measurements[1].weight);
            Assert.AreEqual(_measurement.date, _person.measurements[1].date);
        }
        
        [Then(@"the measurement should be removed from the object")]
        public void ThenTheMeasurementShouldBeRemovedFromTheObject()
        {
            Assert.AreEqual(1, _person.measurements.Count);
        }

        [Then(@"the last measurement is returned")]
        public void ThenTheLastMeasurementIsReturned()
        {
            Assert.AreEqual(_measurement, _person.getLastMeasurement());
        }

        [Then(@"the BMI result is returned for the last enterd measurement")]
        public void ThenTheBMIResultIsReturnedForTheLastEnterdMeasurement()
        {
            Assert.AreEqual(BMI_REF, _BMI);
        }
    }
}
