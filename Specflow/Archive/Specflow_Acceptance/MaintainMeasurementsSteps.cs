using System;
using System.Linq;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Specflow_Acceptance
{
    [Binding]
    public class MaintainMeasurementDataOfAUserSteps
    {
        private Person _person;
        private int _length;
        private int _weight;
        private DateTime _date;
        private Measurement _measurement;
        private Measurement _measurementBuf;
        
        [Given(@"I provide valid measurement data")]
        public void GivenIProvideValidMeasurementData()
        {
            _length = 185;
            _weight = 65000;
            _date = DateTime.Now;
        }

        [When(@"I try to add the new measurement")]
        public void WhenITryToAddTheNewMeasurement()
        {
            _person = ScenarioContext.Current.Get<Person>("User");

            try
            {
                _person.addMeasurement(new Measurement(_length, _weight, _date));
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [Then(@"the new measurement is added to my BMI history")]
        public void ThenTheNewMeasurementIsAddedToMyBMIHistory()
        {
            Measurement m1 = new Measurement(_length, _weight, _date);
            Measurement m2 = _person.measurements.First(e => e.length == _length && e.weight == _weight && e.date == _date);
            
            Assert.AreEqual(m1.length, m2.length);
            Assert.AreEqual(m1.weight, m2.weight);
            Assert.AreEqual(m1.date, m2.date);
        }

        [Given(@"I provide data which is invalid")]
        public void GivenIProvideDataWhichIsInvalid(Table tbl)
        {
            _length = int.Parse(tbl.Rows[0]["Length"]);
            _weight = int.Parse(tbl.Rows[0]["Weight"]);
            _date = DateTime.Parse(tbl.Rows[0]["Date"]);
        }
        
        [Given(@"a valid user which has a valid measurement")]
        public void GivenAValidUserWhichHasAValidMeasurement()
        {
            _measurementBuf = new Measurement(180, 75000, DateTime.Now);
            _person = new Person("1", new DateTime(1986, 5, 2), PersonDef.Gender.Male, _measurementBuf);
        }

        [When(@"i try to fetch the most recent measurement")]
        public void WhenITryToFetchTheMostRecentMeasurement()
        {
            _measurement = _person.getLastMeasurement();
        }

        [Then(@"the requested measurement is returned")]
        public void ThenTheRequestedMeasurementIsReturned()
        {
            Assert.AreEqual(_measurementBuf, _measurement);
        }

        [When(@"i try to remove the most recent measurement")]
        public void WhenITryToRemoveTheMostRecentMeasurement()
        {
            _person.removeLastMeasurement();
        }

        [Then(@"the measurement is removed")]
        public void ThenTheMeasurementIsRemoved()
        {
            Assert.AreEqual(0, _person.measurements.Count);
        }
    }
}
