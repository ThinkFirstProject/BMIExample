using System;
using System.Collections.Generic;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Specflow_Unit
{
    [Binding]
    public class PersonManagerSteps
    {
        private const int NORMAL_WEIGHT = 75000;
        private const int NORMAL_LENGTH = 180;
        private static readonly DateTime BIRTHDATE = new DateTime(2013, 10, 5);
        private static readonly DateTime DATE = new DateTime(2013, 10, 5);

        private PersonManager _manager;
        private Person _person;
        private object _result;

        [Given(@"the singleton instance of personmanager is fetched")]
        public void GivenTheSingletonInstanceOfPersonmanagerIsFetched()
        {
            _manager = PersonManager.instance;
        }

        [Given(@"a valid person is provided")]
        public void GivenAValidPersonIsProvided()
        {
            _person = new Person("10", BIRTHDATE, PersonDef.Gender.Male, new Measurement(NORMAL_LENGTH,NORMAL_WEIGHT,DATE));   
        }

        [Given(@"a person which is null")]
        public void GivenAPersonWhichIsNull()
        {
            _person = null;
        }

        [Given(@"a valid person is added with social security number (.*)")]
        public void GivenAValidPersonIsAddedWithSocialSecurityNumber(String value)
        {
            _person = new Person(value, BIRTHDATE, PersonDef.Gender.Male, new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, DATE));   
        }

        [When(@"i try to fetch the person with an invalid social security number of (.*), which is invalid because: (.*)")]
        public void WhenITryToFetchThePersonWithAnInvalidSocialSecurityNumberOfWhichIsInvalidBecauseValueIsEmpty(String value, String reason)
        {
            String socNr;

            if (value == "null")
            {
                socNr = null;
            }
            else
            {
                socNr = value;
            }

            _result = _manager.getPerson(socNr);
        }

        [When(@"i try to add the person")]
        public void WhenITryToAddThePerson()
        {
            try
            {
                _manager.addPerson(_person);
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [When(@"i try to fetch the person with social security number (.*)")]
        public void WhenITryToFetchThePersonWithSocialSecurityNumber(String value)
        {
            _result = _manager.getPerson(value);
        }
        
        [When(@"i try to fetch a list of existing social security numbers")]
        public void WhenITryToFetchAListOfExistingSocialSecurityNumbers()
        {
            _result = _manager.getSocialSecurityNumbers();
        }

        [Then(@"the person is added")]
        public void ThenThePersonIsAdded()
        {
            Assert.AreEqual(_person.socialSecurityNumber, _manager.personList[0].socialSecurityNumber);
            Assert.AreEqual(_person.gender, _manager.personList[0].gender);
            Assert.AreEqual(_person.birthDate, _manager.personList[0].birthDate);
            Assert.AreEqual(_person.measurements, _manager.personList[0].measurements);
        }

        [Then(@"the person object is returned")]
        public void ThenThePersonObjectIsReturned()
        {
            Assert.AreEqual(_person.socialSecurityNumber, ((Person)_result).socialSecurityNumber);
            Assert.AreEqual(_person.gender, ((Person)_result).gender);
            Assert.AreEqual(_person.birthDate, ((Person)_result).birthDate);
        }

        [Then(@"a null value should be returned")]
        public void ThenANullValueShouldBeReturned()
        {
            Assert.IsNull(_result);
        }

        [Then(@"a list which contains (.*) social security number is returned")]
        public void ThenAListWhichContainsSocialSecurityNumberIsReturned(int value)
        {
            Assert.AreEqual(value, ((List<String>)_result).Count);
        }
    }
}
