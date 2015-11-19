using System;
using System.Reflection;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Service
{
    [TestClass]
    [Story(
        AsA = "a user",
        IWant = "to register anamnesis data of a person",
        SoThat = "the BMI of a person can be calculated")]
    public class RegisterAnamnesisData
    {
        #region Variables
        public const String _SOCSECNR = "123456789";
        public const PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        public static readonly DateTime _BIRTHDATE = new DateTime(1986, 5, 2);

        public const int _LENGTH = 180;
        public const int _WEIGHT = 75000;
        public static readonly DateTime _DATE = new DateTime(2013, 10, 5);

        public Person _person;
        public int _length;
        public int _weight;
        public DateTime _date;
        public Exception _ex;
        #endregion

        #region Properties
        public String Field { get; set; }
        public String InvalidValue { get; set; }
        #endregion

        #region Specs
        [TestMethod]
        public void AMeasurementWithNewAnamnesisDataCanBeAdded()
        {
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .When(_ => _.IProvideAsLength("180"), "When I provide as length 180") 
                .And(_ => _.IProvideAsWeight("75000"), "And I provide as weight 75000")
                .And(_ => _.IProvideAsDate("12-12-2012"), "And I provide as date 12-12-2012")
                .And(_ => _.ITryToAddTheMeasurementToThisPerson(), "And I try to add the measurement to this person")
                .Then(_ => _.aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided(), "Then a new measurement is added to the anamnesis history of this person with the data provided")
                .BDDfy("A measurement with new anamnesis data can be added");
        }

        [TestMethod]
        public void AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid()
        {
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .When(_ => _.IProvideAs(), "I provide <InvalidValue> as <Field>")
		        .And(_ => _.allOtherDataIsValid(), "And all other data is valid")
                .And(_ => _.ITryToAddTheMeasurementToThisPerson(), "And I try to add the measurement to this person")
                .Then(_ => _.anErrorMessageIsGiven() , "Then an error message is given")
                .WithExamples(@"
                | Field  | InvalidValue |
		        | Length | 49           |
		        | Weight | 299          |
		        | Date   | 10-10-3016	|
                ")
                .BDDfy("A new measurement can be created with a length, a weight and a date");
        }

        [TestMethod]
        public void AnErrorMessageIsGivenIfAMeasurementIsAlreadyRegisteredForTheCurrentDateAndTime()
        {
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => _.thePersonHasAMeasurementOn("9-9-2009"), "And the person has a measurement on 9-9-2009")
                .When(_ => _.IProvideAsDate("9-9-2009"), "When I provide as length 180")
                .And(_ => _.allOtherDataIsValid(), "And all other data is valid")
                .And(_ => _.ITryToAddTheMeasurementToThisPerson(), " And I try to add the measurement to this person")
                .Then(_ => _.anErrorMessageIsGiven(), "Then an error message is given")
                .BDDfy("An error message is given if a measurement is already registered for the current date and time");
        }
        
        #endregion

        #region Steps
        public void anExistingPerson()
        {
            _person = new Person(_SOCSECNR, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }

        public void IProvideAsLength(String value)
        {
            _length = int.Parse(value);
        }

        public void IProvideAsWeight(String value)
        {
            _weight = int.Parse(value);
        }

        public void IProvideAsDate(string value)
        {
            _date = DateTime.Parse(value);
        }

        public void ITryToAddTheMeasurementToThisPerson()
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

        public void aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided()
        {
            Assert.IsTrue(_person.measurements.Count == 2);
            Assert.AreEqual(_person.measurements[1].length, _length);
            Assert.AreEqual(_person.measurements[1].weight, _weight);

            Assert.IsTrue(_person.measurements.Exists(e => e.date.Day == _date.Day &&
                                                           e.date.Month == _date.Month &&
                                                           e.date.Year == _date.Year));
        }

        public void anErrorMessageIsGiven()
        {
            Assert.IsNotNull(_ex);
            Assert.IsFalse(String.IsNullOrEmpty(_ex.Message));
        }

        public void allOtherDataIsValid()
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

        public void IProvideAs()
        {
            MethodInfo method = GetType().GetMethod("IProvideAs" + Field);
            method.Invoke(this, new object[] {InvalidValue});
        }

        public void thePersonHasAMeasurementOn(string date)
        {
            _person.addMeasurement(new Measurement(_LENGTH, _WEIGHT, DateTime.Parse(date)));
        }

        #endregion
    }
}
