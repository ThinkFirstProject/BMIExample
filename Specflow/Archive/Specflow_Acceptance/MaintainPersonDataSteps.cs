using System;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Specflow_Acceptance
{
    [Binding]
    public class MaintainingThePersonalDataOfAUserSteps
    {
        private String _socialSecNumber;
        private PersonDef.Gender _gender;
        private DateTime _birthDate;
        private Measurement _measurement;
        private Person _person;

        [Given(@"valid personal data is provided")]
        public void GivenValidPersonalDataIsProvided()
        {
            _socialSecNumber = "1";
            _gender = PersonDef.Gender.Male;
            _birthDate = new DateTime(2001,1,1);
        }

        [Given(@"a valid starting measurement is provided")]
        public void GivenAValidStartingMeasurementIsProvided()
        {
            _measurement = new Measurement(180, 60000, DateTime.Now);
        }
        
        [Given(@"personal data is provided which is invalid")]
        public void GivenPersonalDataIsProvidedWhichIsInvalid(Table table)
        {
            if (table.Rows[0]["Social security number"] == "null")
            {
                _socialSecNumber = null;
            }
            else
            {
                _socialSecNumber = table.Rows[0]["Social security number"];
            }

            Enum.TryParse(table.Rows[0]["Gender"], false, out _gender);
            
            DateTime.TryParse(table.Rows[0]["Birthdate"], out _birthDate);
        }

        [Given(@"an invalid first measurement is provide")]
        public void GivenAnInvalidFirstMeasurementIsProvide()
        {
            _measurement = null;
        }

        [Given(@"new valid personal data is provided")]
        public void GivenNewValidPersonalDataIsProvided()
        {
            _socialSecNumber = "2";
            _gender = PersonDef.Gender.Female;
            _birthDate = new DateTime(2002, 1, 1);
        }

        [Given(@"new invalid personal data is provided")]
        public void GivenNewInvalidPersonalDataIsProvided(Table table)
        {
            if (table.Rows[0]["Social security number"] == "null")
            {
                _socialSecNumber = null;
            }
            else
            {
                _socialSecNumber = table.Rows[0]["Social security number"];   
            }
            
            Enum.TryParse(table.Rows[0]["Gender"], false, out _gender);
            DateTime.TryParse(table.Rows[0]["Birthdate"], out _birthDate);
        }
        
        [Given(@"an invalid first measurement is provided")]
        public void GivenAnInvalidFirstMeasurementIsProvided()
        {
            _measurement = null;
        }

        [When(@"i try to generate a new user")]
        public void WhenITryToGenerateANewUser()
        {
            try
            {
                _person = new Person(_socialSecNumber, _birthDate, _gender, _measurement);
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }
        
        [When(@"i try to change the personal data of the user")]
        public void WhenITryToChangeThePersonalDataOfTheUser()
        {
            _person = ScenarioContext.Current.Get<Person>("User");

            try
            {
                _person.birthDate = _birthDate;
                _person.gender = _gender;
                _person.socialSecurityNumber = _socialSecNumber;
            }
            catch (Exception ex)
            {
                ScenarioContext.Current.Add("Error", ex);
            }
        }

        [Then(@"the new user is generated")]
        public void ThenTheNewUserIsGenerated()
        {
            Assert.AreEqual(_socialSecNumber, _person.socialSecurityNumber);   
            Assert.AreEqual(_birthDate, _person.birthDate);
            Assert.AreEqual(_gender, _gender);
        }

        [Then(@"the personal data of the user is changed")]
        public void ThenThePersonalDataOfTheUserIsChanged()
        {
            Assert.AreEqual(_socialSecNumber, _person.socialSecurityNumber);
            Assert.AreEqual(_birthDate, _person.birthDate);
            Assert.AreEqual(_gender, _gender);
        }
    }
}
