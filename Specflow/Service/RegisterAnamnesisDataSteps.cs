using System;
using System.Linq;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Service
{
    [Binding]
    public class RegisterAmnesisDataSteps
    {
        private const String _SOCSECNR = "123456789";
        private const PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        private static readonly DateTime _BIRTHDATE = new DateTime(1986, 5 ,2);

        private const int _LENGTH = 180;
        private const int _WEIGHT = 75000;
        private static readonly DateTime _DATE = new DateTime(2013, 10, 5);

        private Person _person;
        private int _length;
        private int _weight;
        private DateTime _date;
        private Exception _ex;

        [Given(@"an existing person")]
        public void GivenAnExistingPerson()
        {
            _person = new Person(_SOCSECNR, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }
        
        [Given(@"the person has a measurement on (.*)")]
        public void GivenThePersonHasAMeasurementOn(string date)
        {
            _person.addMeasurement(new Measurement(_LENGTH, _WEIGHT, DateTime.Parse(date)));
        }

        [When(@"I provide as length (.*)")]
        public void WhenIProvideAsLength(int value)
        {
            _length = value;
        }

        [When(@"I provide as weight (.*)")]
        public void WhenIProvideAsWeight(int value)
        {
            _weight = value;
        }

        [When(@"I provide as date (.*)")]
        public void WhenIProvideAsDate(string date)
        {
            _date = DateTime.Parse(date);
        }

        [When(@"I try to add the measurement to this person")]
        public void WhenITryToAddTheMeasurementToThisPerson()
        {
            try
            {
                _person.addMeasurement(new Measurement(_length, _weight, _date));
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"I provide (.*) as length")]
        public void WhenIProvideValAsLength(int value)
        {
            _length = value;
        }

        [When(@"I provide (.*) as weight")]
        public void WhenIProvideValAsWeight(int value)
        {
            _weight = value;
        }

        [When(@"I provide (.*) as date")]
        public void WhenIProvideValAsDate(string value)
        {
            _date = DateTime.Parse(value);
        }

        [When(@"all other data is valid")]
        public void WhenAllOtherDataIsValid()
        {
            if (_length == 0)
            {
                _length = _LENGTH;
            }

            if (_weight == 0)
            {
                _weight = _WEIGHT;
            }

            if (_date.Year == 1)
            {
                _date = new DateTime(_DATE.Year, _DATE.Month, _DATE.Day + 1);
            }
        }

        [Then(@"a new measurement is added to the anamnesis history of this person with the data provided")]
        public void ThenANewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided()
        {
            Assert.IsTrue(_person.measurements.Count == 2);
            Assert.AreEqual(_person.measurements[1].length, _length);
            Assert.AreEqual(_person.measurements[1].weight, _weight);

            Assert.IsTrue(_person.measurements.Exists(e => e.date.Day == _date.Day &&
                                                           e.date.Month == _date.Month &&
                                                           e.date.Year == _date.Year));
        }

        [Then(@"an error message is given")]
        public void ThenAnErrorMessageIsGiven()
        {
            Assert.IsNotNull(_ex);
            Assert.IsFalse(String.IsNullOrEmpty(_ex.Message));
        }
    }
}
