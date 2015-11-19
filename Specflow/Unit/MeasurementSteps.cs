using System;
using BMI.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Unit
{
    [Binding]
    public class SpecificationsForAMeasurementSteps
    {
        private const int _LENGTH = 180;
        private const int _WEIGHT = 75000;
        private static readonly DateTime _DATE = new DateTime(2013, 10, 5);

        private Measurement _measurement;
        private Measurement _otherMeasurement;
        private int _length;
        private int _weight;
        private DateTime _date;
        private Exception _ex;
        private Object _result;

        [Given(@"an existing measurement")]
        public void GivenAnExistingMeasurement()
        {
            _measurement = new Measurement(_LENGTH, _WEIGHT, _DATE);
        }

        [Given(@"an existing measurement with length (.*), weight (.*) and date ""(.*)""")]
        public void GivenAnExistingMeasurementWithLengthWeightAndDate(int length, int weight, string date)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Parse(date);

            _measurement = new Measurement(_length, _weight, _date);
        }

        [Given(@"another existing measurement with another length (.*), another weight (.*) and the same date ""(.*)""")]
        public void GivenAnotherExistingMeasurementWithAnotherLengthAnotherWeightAndTheSameDate(int length, int weight, string date)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Parse(date);

            _otherMeasurement = new Measurement(_length, _weight, _date);
        }

        [Given(@"another existing measurement with the same length (.*), the same weight (.*) and another date ""(.*)""")]
        public void GivenAnotherExistingMeasurementWithTheSameLengthTheSameWeightAndAnotherDate(int length, int weight, string date)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Parse(date);

            _measurement = new Measurement(_length, _weight, _date);
        }

        [Given(@"an existing measurement with date ""(.*)""")]
        public void GivenAnExistingMeasurementWithDate(string date)
        {
            _date = DateTime.Parse(date);

            _measurement = new Measurement(_LENGTH, _WEIGHT, _date);
        }

        [Given(@"another existing measurement with date ""(.*)""")]
        public void GivenAnotherExistingMeasurementWithDate(string date)
        {
            _date = DateTime.Parse(date);
            _otherMeasurement = new Measurement(_LENGTH, _WEIGHT, _date);
        }

        [When(@"I want to make a new measurement with length (.*), weight (.*) and date (.*)")]
        public void WhenIWantToMakeANewMeasurementWithLengthWeightAndDate(int length, int weight, string date)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Parse(date);

            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"I want to make a new measurement with length (.*), weight (.*) and the current date")]
        public void WhenIWantToMakeANewMeasurementWithLengthWeightAndTheCurrentDate(int length, int weight)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Now;

            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"I want to make a new measurement with invalid length (.*), valid weight (.*) and valid date (.*)")]
        public void WhenIWantToMakeANewMeasurementWithInvalidLengthValidWeightAndValidDate(int length, int weight, string date)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Parse(date);

            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"I want to make a new measurement with invalid length (.*), valid weight (.*) and the current date")]
        public void WhenIWantToMakeANewMeasurementWithInvalidLengthValidWeightAndTheCurrentDate(int length, int weight)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Now;

            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"I want to make a new measurement with valid length (.*),  invalid weight (.*) and valid date (.*)")]
        public void WhenIWantToMakeANewMeasurementWithValidLengthInvalidWeightAndValidDate(int length, int weight, string date)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Parse(date);

            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"I want to make a new measurement with valid length (.*), invalid weight (.*) and the current date")]
        public void WhenIWantToMakeANewMeasurementWithValidLengthInvalidWeightAndTheCurrentDate(int length, int weight)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Now;

            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"I want to make a new measurement with valid length (.*),  valid weight (.*) and invalid date (.*)")]
        public void WhenIWantToMakeANewMeasurementWithValidLengthValidWeightAndInvalidDate(int length, int weight, string date)
        {
            _length = length;
            _weight = weight;
            _date = DateTime.Parse(date);

            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }
        
        [When(@"I change the length to (.*) which is (.*)")]
        public void WhenIChangeTheLengthToWhichIsANormalLength(int length, string remark)
        {
            _length = length;

            try
            {
                _measurement.length = _length;
            }
            catch (Exception ex)
            {

                _ex = ex;
            }
        }

        [When(@"I change the weight to (.*) which is (.*)")]
        public void WhenIChangeTheWeightToWhichIsANormalWeight(int weight, string remark)
        {
            _weight = weight;

            try
            {
                _measurement.weight = _weight;
            }
            catch (Exception ex)
            {

                _ex = ex;
            }
        }
        
        [When(@"I change the date to (.*) which is (.*)")]
        public void WhenIChangeTheDateToWhichIsADateInPast(string date, String remark)
        {
            _date = DateTime.Parse(date);

            try
            {
                _measurement.date = _date;
            }
            catch (Exception ex)
            {

                _ex = ex;
            }
        }
        
        [When(@"I check if these measurements are equal to each other")]
        public void WhenICheckIfTheseMeasurementsAreEqualToEachOther()
        {
            _result = _measurement.equals(_otherMeasurement);
        }

        [When(@"I compare the measurement with date ""(.*)"" with the measurement with date ""(.*)""")]
        public void WhenICompareTheMeasurementWithDateWithTheMeasurementWithDate(string date1, string date2)
        {
            _result = _measurement.CompareTo(_otherMeasurement);
        }

        [Then(@"A new measurement is created")]
        public void ThenANewMeasurementIsCreated()
        {
            Assert.IsNotNull(_measurement);
        }

        [Then(@"the length is (.*)")]
        public void ThenTheLengthIs(int length)
        {
            Assert.AreEqual(length, _measurement.length);
        }

        [Then(@"the weight is (.*)")]
        public void ThenTheWeightIs(int weight)
        {
            Assert.AreEqual(weight, _measurement.weight);
        }

        [Then(@"the date is (.*)")]
        public void ThenTheDateIs(string date)
        {
            DateTime mDate;

            if (date == "the current date")
            {
                mDate = DateTime.Now;
            }
            else
            {
                mDate = DateTime.Parse(date);   
            }
             
            Assert.AreEqual(mDate.Day, _measurement.date.Day);
            Assert.AreEqual(mDate.Month, _measurement.date.Month);
            Assert.AreEqual(mDate.Year, _measurement.date.Year);
        }
        
        [Then(@"an exception is thrown")]
        public void ThenAnExceptionIsThrown()
        {
            Assert.IsNotNull(_ex);
        }
        
        [Then(@"true is returned")]
        public void ThenTrueIsReturned()
        {
            Assert.IsTrue((Boolean)_result);
        }

        [Then(@"false is returned")]
        public void ThenFalseIsReturned()
        {
            Assert.IsFalse((Boolean)_result);
        }

        [Then(@"a positive number is returned")]
        public void ThenAPositiveNumberIsReturned()
        {
            Assert.IsTrue((int)_result > 0);
        }

        [Then(@"a negative number is returned")]
        public void ThenANegativeNumberIsReturned()
        {
            Assert.IsTrue((int)_result < 0);
        }

        [Then(@"the number (.*) is returned")]
        public void ThenTheNumberIsReturned(int value)
        {
            Assert.IsTrue((int)_result == value);
        }

        [When(@"the length is (.*) and the weight is (.*)")]
        public void WhenTheLengthIsAndTheWeightIs(int length, int weight)
        {
            _measurement.length = length;
            _measurement.weight = weight;
        }

        [Then(@"the bmi is (.*)")]
        public void ThenTheBmiIs(Double result)
        {
            Assert.AreEqual(result, _measurement.getBMI());
        }

    }
}
