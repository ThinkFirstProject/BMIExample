using System;
using BMIExample.Models.Containers;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace BMITestNBehave
{
    [ActionSteps]
    public class MaintainMeasurementDataSteps
    {
        private int _weight;
        private int _length;
        private DateTime _date;
        private Measurement _measurement;
        [Given("A valid measurement object is generated: $weight g , $length cm , \"$date\"")]
        public void GivenAValidMeasurementObjectIsGenerated(int weight , int length, String date)
        {
            _length = length;
            _weight = weight;
            
            _date =  DateTime.Parse(date);
            
            _measurement = new Measurement(_length, _weight, _date);
        }

        [When(@"The date is changed with a valid value: $day - $month - $year")]
        public void WhenTheDateIsChangedWithAValidValue(int day, int month, int year)
        {
            _date = new DateTime(year, month, day);
            _measurement.date = _date;
        }

        [When(@"A valid weight is enterd: $weight g")]
        public void WhenAValidWeightIsEnterd(int weight)
        {
            _weight = weight;
        }

        [When("A valid date is enterd: \"$date\"")]
        public void WhenAValidDateIsEnterd(String date)
        {
            _date = DateTime.Parse(date); 
        }

        [When(@"A valid length is enterd: $parameterName -> $length")]
        public void WhenAValidLengthIsEnterd(string parameterName, int length)
        {
            _length = length;
        }

        [When(@"An invalid length is enterd: $parameterName -> $length")]
        public void WhenAnInvalidLengthIsEnterd(string parameterName, int length)
        {
            _length = length;
        }

        [When(@"The measurement object is generated")]
        public void WhenTheMeasurementObjectIsGenerated()
        {
            try
            {
                ScenarioContext.Current.Remove("Error");
                new Measurement(_length, _weight, _date);
            }
            catch (ArgumentException exception)
            {
                if (ScenarioContext.Current.ContainsKey("Error"))
                {
                    ScenarioContext.Current["Error"] = exception.Message;
                }
                else
                {
                    ScenarioContext.Current.Add("Error", exception.Message);
                }
            }
        }

        [When(@"The length is changed: $parameterName -> $length")]
        public void WhenTheLengthIsChanged(string parameterName, int length)
        {
            try
            {
                _measurement.length = length;
                _length = length;
            }
            catch (Exception exception)
            {
                
                ScenarioContext.Current["Error"] = exception.Message;
            }
        }
        
        [Then(@"The measurement object should be updated with the new length")]
        public void ThenTheMeasurementObjectShouldBeUpdatedWithTheNewLength()
        {
            Assert.AreEqual(_measurement.length, _length);
        }

        [Then(@"The measurement object should throw an error and the length should not be changed")]
        public void ThenTheMeasurementObjectShouldThrowAnErrorAndTheLengthShouldNotBeChanged()
        {
            Assert.AreEqual(ScenarioContext.Current["Error"], "Not a valid length");
            Assert.AreEqual(_measurement.length, _length);
        }

        [Then(@"The measurement object should contain the enterd data")]
        public void ThenTheMeasurementObjectShouldContainTheEnterdData()
        {
            Measurement measurement = new Measurement(_length, _weight, _date);

            Assert.AreEqual(_length, measurement.length);
            Assert.AreEqual(_weight, measurement.weight);
            Assert.AreEqual(_date, measurement.date);
        }

        [Then(@"The measurement object should throw an invalid length error")]
        public void ThenTheMeasurementObjectShouldThrowAnInvalidLengthError()
        {
            Assert.AreEqual(ScenarioContext.Current["Error"], "Not a valid length");
        }

        [Then(@"The measurement object should be updated with the new date")]
        public void ThenTheMeasurementObjectShouldBeUpdatedWithTheNewDate()
        {
            Assert.AreEqual(_measurement.date, _date);
        }
    }
}
