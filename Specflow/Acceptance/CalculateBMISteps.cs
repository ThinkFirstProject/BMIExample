using System;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Acceptance
{
    [Binding]
    public class CalculateBMISteps
    {
        private const String _SOCSECNR = "123456789";
        private const PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        private static readonly DateTime _BIRTHDATE = new DateTime(1986, 5, 2);

        private const int _LENGTH = 180;
        private const int _WEIGHT = 75000;
        private static readonly DateTime _DATE = new DateTime(2013, 10, 5);

        private Person _person ;
        private double _BMI;

        [Given(@"an existing person")]
        public void GivenAnExistingPerson()
        {
            _person = new Person(_SOCSECNR, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }

        [Given(@"a last measurement with length (.*) and weight (.*)")]
        public void GivenALastMeasurementWithLengthAnd(int length, int weight)
        {
            _person.addMeasurement(new Measurement(length, weight, DateTime.Now));
        }

        [Given(@"a measurement on (.*) with length (.*) and weight (.*)")]
        public void GivenAMeasurementOnWithLengthAndWeight(string date, int length, int weight)
        {
            _person.addMeasurement(new Measurement(length, weight, DateTime.Parse(date)));
        }
       
        [When(@"I choose to calculate the bmi of this person")]
        public void WhenIChooseToCalculateTheBmiOfThisPerson()
        {
            _BMI = _person.getBMI();
        }

        [Then(@"the bmi is (.*)")]
        public void ThenTheBmiIs(double BMI)
        {
            Assert.AreEqual(BMI, _BMI);
        }
    }
}
