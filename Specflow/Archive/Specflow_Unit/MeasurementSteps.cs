using System;
using BMI.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Specflow_Unit
{
    [Binding]
    public class MeasurementSteps
    {
        private const int NORMAL_WEIGHT = 75000;
        private const int NORMAL_LENGTH = 180;
        private static readonly DateTime NORMAL_DATE = new DateTime(2013, 10, 5);

        private int _weight;
        private int _length;
        private DateTime _date;
        private Measurement _measurement;
        private Measurement _otherMeasurement;
        private object _result;
        private Exception _ex;

        [BeforeScenario]
        private void setUp()
        {
            _weight = -10;
            _length = -10;
        }

        [Given(@"a length (.*) is provided")]
        public void GivenALengthIsProvided(int length)
        {
            _length = length;
        }

        [Given(@"a weight  (.*) is provided")]
        public void GivenAWeightIsProvided(int weight)
        {
            _weight = weight;
        }

        [Given(@"a valid date is enterd")]
        public void GivenAValidDateIsEnterd()
        {
            _date = DateTime.Now;
        }

        [Given(@"an invalid length (.*) is provided, which is invalid because (.*)")]
        public void GivenAnInvalidLengthIsProvidedWhichIsInvalidBecauseLotToSmallLength(int length, String reason)
        {
            _length = length;
        }

        [Given(@"all other parameters are valid")]
        public void GivenAllOtherParametersAreValid()
        {
            if (_length == -10)
            {
                _length = NORMAL_LENGTH;
            }

            if (_weight == -10)
            {
                _weight = NORMAL_WEIGHT;
            }

            _date = NORMAL_DATE;
        }

        [Given(@"an invalid weight (.*) is provided, which is invalid because (.*)")]
        public void GivenAnInvalidWeightIsProvidedWhichIsInvalidBecauseLotToSmallWeight(int weight, String reason)
        {
            _weight = weight;
        }

        [Given(@"a valid measurement object")]
        public void GivenAValidMeasurementObject()
        {
            _measurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
        }
        
        [Given(@"a valid measurement object with date (.*)")]
        public void GivenAValidMeasurementObjectIsGeneratedWithDate(String date)
        {
            _date = DateTime.Parse(date);
            _measurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, _date);
        }

        [Given(@"another measurement object is created with the date (.*) which is (.*)")]
        public void GivenAnotherMeasurementObjectIsCreatedWithTheDateWhichIsAnEarlierDate(String date, String circumstance)
        {
            _otherMeasurement = new Measurement(NORMAL_LENGTH,NORMAL_WEIGHT, DateTime.Parse(date));
        }
        
        [Given(@"another measurement object is created which is null")]
        public void GivenAnotherMeasurementObjectIsCreatedWhichIsNull()
        {
            _otherMeasurement = null;
        }

        [When(@"i try to create a new measurement object with (.*)")]
        public void WhenITryToCreateANewMeasurementObjectWithNormalLength(String circumstance)
        {
            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"i try to create a new measurement")]
        public void WhenITryToCreateANewMeasurement()
        {
            try
            {
                _measurement = new Measurement(_length, _weight, _date);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
            
        }

        [When(@"i try to change the length to (.*), which is (.*)")]
        public void WhenITryToChangeTheLengthToWhichIsOTHER_NormalLength(int length, string circumstance)
        {
            try
            {
                _length = length;
                _measurement.length = length;
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"i try to change the weight to (.*), which is (.*)")]
        public void WhenITryToChangeTheWeightToWhichIsOTHER_NormalWeight(int weight, String circumstance)
        {
            try
            {
                _weight = weight;
                _measurement.weight = weight;
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }
        
        [When(@"the date is changed with a valid value: (.*)")]
        public void WhenTheDateIsChangedWithAValidValue(String date)
        {
            _date = DateTime.Parse(date);
            _measurement.date = _date;
        }
        
        [When(@"the measurement object is compared to the other measurement")]
        public void WhenTheMeasurementObjectIsComparedToTheOtherMeasurement()
        {
            _result = _measurement.CompareTo(_otherMeasurement);
        }

        [When(@"i try to check for equality between both measurements")]
        public void WhenITryToCheckForEqualityBetweenBothMeasurements()
        {
            _result = _measurement.@equals(_otherMeasurement);
        }

        [Then(@"the measurement object is created with the enterd data")]
        public void ThenTheMeasurementObjectIsCreated()
        {
            Assert.AreEqual(_length, _measurement.length);
            Assert.AreEqual(_weight, _measurement.weight);
            Assert.AreEqual(_date, _measurement.date);
        }
        
        [Then(@"the measurement object should throw an argument exception")]
        public void ThenTheMeasurementObjectShouldThrowAnArgumentException()
        { 
            Assert.IsNotNull(_ex);
            Assert.IsInstanceOfType(_ex, typeof(ArgumentException));
        }

        [Then(@"the measurement object should be updated with the new length value")]
        public void ThenTheMeasurementObjectShouldBeUpdatedWithTheNewLengthValue()
        {
            Assert.AreEqual(_length, _measurement.length);
        }

        [Then(@"the measurement object should be updated with the new weight value")]
        public void ThenTheMeasurementObjectShouldBeUpdatedWithTheNewWeightValue()
        {
            Assert.AreEqual(_weight, _measurement.weight);
        }

        [Then(@"the measurement object should be updated with the new date")]
        public void ThenTheMeasurementObjectShouldBeUpdatedWithTheNewDate()
        {
            Assert.AreEqual(_date, _measurement.date);
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBePositive(String result)
        {
            switch (result)
            {
                case "true":
                    Assert.IsTrue((Boolean)_result);
                    break;
                case "false":
                    Assert.IsFalse((Boolean)_result);
                    break;
                case "positive":
                    Assert.IsTrue((int)_result > 0);
                    break;
                case "negative":
                    Assert.IsTrue((int)_result < 0);
                    break;
                case "zero":
                    Assert.AreEqual(0, (int)_result);
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
