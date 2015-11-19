using System;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace CalculateBMI
{
    [TestClass]
    [Story(
        AsA = "a user",
        IWant = "ask the bmi of a person",
        SoThat = "the person's medical condition can be assessed")]
    public class CalculateBMI
    {
        #region Variables
        private const String _SOCSECNR = "123456789";
        private const PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        private static readonly DateTime _BIRTHDATE = new DateTime(1986, 5, 2);

        private const int _LENGTH = 180;
        private const int _WEIGHT = 75000;
        private static readonly DateTime _DATE = new DateTime(2013, 10, 5);

        private Person _person;
        private double _BMI;
        #endregion

        #region Properties
        public int LengthVal { get; set; }
        public int WeightVal { get; set; }
        public double BmiVal { get; set; }
        #endregion

        #region Specs
        [TestMethod]
        public void TheBmiIsCalculatedBasedOnTheLengthAndTheWeightOfAPerson()
        {
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => _.aLastMeasurementWithLengthAndWeight(), "And a last measurement with length <LengthVal> and weight <WeightVal>")
                .When(_ => _.IChooseToCalculateTheBmiOfThisPerson(), "When I choose to calculate the bmi of this person")
                .Then(_ => _.theBmiIs(), "Then the bmi is <BmiVal>")
                .WithExamples(@"
                | LengthVal | WeightVal | BmiVal|
	            | 160       | 65000     | 25,39 |
	            | 180       | 75000     | 23,15 |    
                ")
                .BDDfy("The bmi is calculated based on the length and the weight of a person");
        }

        [TestMethod]
        public void TheBmiIsCalculatedBasedOnTheMostRecentAnamnesisOfThePerson()
        {
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => _.aMeasurementOnWithLengthAndWeight("12-12-2012", 180, 65000), "And a measurement on 12-12-2012 with length 180 and weight 65000")
                .And(_ => _.aMeasurementOnWithLengthAndWeight("12-12-2013", 180, 75000), "And a measurement on 12-12-2013 with length 180 and weight 75000")
                .When(_ => _.IChooseToCalculateTheBmiOfThisPerson(), "When I choose to calculate the bmi of this person")
                .Then(_ => _.theBmiIs(23.15), "Then the bmi is 23.15")
                .BDDfy("The bmi is calculated based on the most recent anamnesis of the person");
        }

        [TestMethod]
        public void TheBmiIsRoundedTo2Digits()
        {
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => aLastMeasurementWithLengthAndWeight(), "And a last measurement with length <LengthVal> and weight <WeightVal>")
                .When(_ => _.IChooseToCalculateTheBmiOfThisPerson(), "When I choose to calculate the bmi of this person")
                .Then(_ => _.theBmiIs(), "Then the bmi is <BmiVal>")
                .WithExamples(@"
                | LengthVal | WeightVal | BmiVal|
	            | 160       | 65000     | 25,39 |
	            | 160       | 65001     | 25,39 |
	            | 160       | 65009     | 25,39 |
	            | 180       | 75000     | 23,15 |
	            | 180       | 75009     | 23,15 |   
                ")
                .BDDfy("The bmi is rounded to 2 digits");
        }
        #endregion

        #region Steps
        private void theBmiIs(double BMI)
        {
            Assert.AreEqual(BMI, _BMI);
        }

        private void aMeasurementOnWithLengthAndWeight(string date, int length, int weight)
        {
            _person.addMeasurement(new Measurement(length, weight, DateTime.Parse(date)));
        }

        private void anExistingPerson()
        {
            _person = new Person(_SOCSECNR, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }

        private void theBmiIs()
        {
            Assert.AreEqual(BmiVal, _BMI);
        }

        private void IChooseToCalculateTheBmiOfThisPerson()
        {
            _BMI = _person.getBMI();
        }

        private void aLastMeasurementWithLengthAndWeight()
        {
            _person.addMeasurement(new Measurement(LengthVal, WeightVal, DateTime.Now));
        }
        #endregion
    }
}
