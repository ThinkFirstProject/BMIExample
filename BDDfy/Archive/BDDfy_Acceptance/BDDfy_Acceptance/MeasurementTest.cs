using System;
using BMI;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;
using TestStack.BDDfy.Configuration;

namespace BDDfy_Acceptance
{
    [TestClass]
    [Story(
    AsA = "user",
    IWant = "to register amnesis data of a person",
    SoThat = "the BMI of a person can be calculated")]

    public class MeasurementTest
    {
        private Person _person;
        private int _length;
        private int _weight;
        private DateTime _date;
        private Exception _ex;

        [TestMethod]
        public void AMeasurementWithNewAnamnesisDataCanBeAdded()
        {
            Configurator.BatchProcessors.HtmlMetroReport.Enable();

            this.Given(_ => _.GivenAnExistingPerson())
                .And("And I want to register new anamnesis data for this person")
                .When(_ => _.IProvideAsLength(180))
                .And(_ => _.IProvideAsWeight(60000))
                .And(_ => _.IProvideAsDate("12-12-2012"))
                .And(_ => _.IChooseToRegister())
                .Then(_ => _.ANewMeasurementIsAddedToTheAnamnesisHistoryWithTheDataProvided())
                .BDDfy();
        }
        
        private void ANewMeasurementIsAddedToTheAnamnesisHistoryWithTheDataProvided()
        {
            Assert.AreEqual(_length, _person.getLastMeasurement().length);
        }

        private void IChooseToRegister()
        {
            try
            {
                _person.addMeasurement(new BMI.Containers.Measurement(_length, _weight, _date));
            }
            catch (Exception ex)
            {

                _ex = ex;
            }
        }



        private void IProvideAsDate(string p)
        {
            _date = DateTime.Parse(p);
        }

        private void IProvideAsWeight(int p)
        {
            _weight = p;
        }

        private void IProvideAsLength(int p)
        {
            _length = p;
        }
        
        private void GivenAnExistingPerson()
        {
            _person = new Person("10", DateTime.Now,PersonDef.Gender.Male, new BMI.Containers.Measurement(180,60000,DateTime.Now));
        }
    }
}
