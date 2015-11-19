using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using BMI.Def;
using BMIWeb.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDbUnit.Core;
using TechTalk.SpecFlow;
using Person = BMI.Person;
using Measurement = BMI.Containers.Measurement;

namespace Database
{
    [Binding]
    public class SavingAndLoadingDataFromTheBMIDataAccessLayerSteps
    {
        private const String _SOCSECNR = "123456789";
        private const PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        private static readonly DateTime _BIRTHDATE = new DateTime(1986, 5, 2);

        private const int _LENGTH = 180;
        private const int _WEIGHT = 75000;
        private static readonly DateTime _DATE = new DateTime(2013, 10, 5);
        private static readonly DateTime _otherDATE = new DateTime(2015, 7, 5);

        private INDbUnitTest _dbDAL;
        private BMIDAL _dal;
        private Person _person;
        private Measurement _measurement;
        private String _socSecNr;
        private Exception _ex;
        private Object _result;

        [BeforeScenario]
        public void setup()
        {
            _dbDAL = new NDbUnit.Core.SqlClient.SqlDbUnitTest(ConfigurationManager.ConnectionStrings["BMIDBCS"].ConnectionString);
            _dbDAL.ReadXmlSchema(@"D:\Elektromap\KHLimCo-op\net\WP3 Onwtikkel-implementatie onderzoek 1\BMIExample\Specflow\Database\DBModel\DSBMI.xsd");           
        }

        [AfterScenario]
        public void tearDown()
        {
            _dbDAL.PerformDbOperation(DbOperationFlag.Delete);
        }

        [Given(@"the BMIDAL")]
        public void GivenTheBMIDAL()
        {
            _dal = new BMIDAL();
        }

        [Given(@"the database contains a person with 123456789 as social security number")]
        public void GivenTheDatabaseContainsAPersonWithAsSocialSecurityNumber()
        {
            _person = new Person("123456789", new DateTime(1986,5,2),PersonDef.Gender.Male, new Measurement(180,65000,new DateTime(2015,08,25)));
            _dbDAL.ReadXml(@"D:\Elektromap\KHLimCo-op\net\WP3 Onwtikkel-implementatie onderzoek 1\BMIExample\Specflow\Database\DBModel\TestData.xml");
            _dbDAL.PerformDbOperation(DbOperationFlag.CleanInsertIdentity);
        }

        [Given(@"the database contains 1 person with social security number 123456789")]
        public void GivenTheDatabaseContainsPersonWithSocialSecurityNumber()
        {
            _dbDAL.ReadXml(@"D:\Elektromap\KHLimCo-op\net\WP3 Onwtikkel-implementatie onderzoek 1\BMIExample\Specflow\Database\DBModel\TestData.xml");
            _dbDAL.PerformDbOperation(DbOperationFlag.CleanInsertIdentity);
        }

        [When(@"a valid person object with anamnesis data is provided")]
        public void WhenAValidPersonObjectWithAnamnesisDataIsProvided()
        {
            _person = new Person(_SOCSECNR, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }

        [When(@"i try to save the person object to the database")]
        public void WhenITryToSaveThePersonObjectToTheDatabase()
        {
            try
            {
                _result = _dal.addPerson(_person);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"a valid person object with anamnesis data is provided with social security number (.*)")]
        public void WhenAValidPersonObjectWithAnamnesisDataIsProvidedWithSocialSecurityNumber(String value)
        {
            _person = new Person(value, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }

        [When(@"a person object is provided,which is null")]
        public void WhenAPersonObjectIsProvidedWhichIsNull()
        {
            _person = null;
        }

        [When(@"an existing social security number is provided")]
        public void WhenAnExistingSocialSecurityNumberIsProvided()
        {
            _socSecNr = "123456789";
        }

        [When(@"i try to fetch the data for the person from the database")]
        public void WhenITryToFetchTheDataForThePersonFromTheDatabase()
        {
            try
            {
                _result = _dal.getPerson(_socSecNr);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"a non-existing social security number is provided")]
        public void WhenANon_ExistingSocialSecurityNumberIsProvided()
        {
            _socSecNr = "1";
        }

        [When(@"a social security number is provided, which is null")]
        public void WhenASocialSecurityNumberIsProvidedWhichIsNull()
        {
            _socSecNr = null;
        }

        [When(@"a valid measurement object is provided")]
        public void WhenAValidMeasurementObjectIsProvided()
        {
            _measurement = new Measurement(_LENGTH, _WEIGHT, _otherDATE);
        }

        [When(@"i try to add the new anamnesis data to the database")]
        public void WhenITryToAddTheNewAnamnesisDataToTheDatabase()
        {
            try
            {
                _dal.addMeasurement(_socSecNr, _measurement);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"a measurement object is provided which is null")]
        public void WhenAMeasurementObjectIsProvidedWhichIsNull()
        {
            _measurement = null;
        }

        [When(@"a social security number (.*) is provided, which is invalid because: (.*)")]
        public void WhenASocialSecurityNumberIsProvidedWhichIsInvalidBecauseValueDoesnTExist(String value, String reason)
        {
            if (value == "null")
            {
                _socSecNr = null;
            }
            else
            {
                _socSecNr = value;    
            }
        }

        [When(@"i try to fetch a list of all stored social security numbers")]
        public void WhenITryToFetchAListOfAllStoredSocialSecurityNumbers()
        {
            _result = _dal.getSocialSecurityNumberList();
        }

        [Then(@"the data of the person object is stored in the database")]
        public void ThenTheDataOfThePersonObjectIsStoredInTheDatabase()
        {
            DataSet result = _dbDAL.GetDataSetFromDb(new StringCollection {"Person", "Measurement"});
            DataTable tbl = result.Tables["Person"];

            Assert.AreEqual(_person.socialSecurityNumber, (String)tbl.Rows[0]["SocialSecurityNumber"]);
            Assert.AreEqual(_person.birthDate, (DateTime)tbl.Rows[0]["BirthDate"]);
            Assert.AreEqual(_person.gender.ToString(), (String)tbl.Rows[0]["Gender"]);

            tbl = result.Tables["Measurement"];

            Assert.AreEqual(_person.socialSecurityNumber, (String)tbl.Rows[0]["SocialSecurityNumber"]);
            Assert.AreEqual(_person.measurements[0].length, (int)tbl.Rows[0]["Length"]);
            Assert.AreEqual(_person.measurements[0].weight, (int)tbl.Rows[0]["Weight"]);
            Assert.AreEqual(_person.measurements[0].date, (DateTime)tbl.Rows[0]["Date"]);
        }

        [Then(@"no changes are made to the database, the entry is ignored")]
        public void ThenNoChangesAreMadeToTheDatabaseTheEntryIsIgnored()
        {
            DataSet result = _dbDAL.GetDataSetFromDb(new StringCollection { "Person", "Measurement" });
            Assert.AreEqual(1, result.Tables["Person"].Rows.Count);
            Assert.AreEqual(1, result.Tables["Measurement"].Rows.Count);
        }

        [Then(@"an exception is thrown")]
        public void ThenAnExceptionIsThrown()
        {
            Assert.IsNotNull(_ex);
        }

        [Then(@"the requested person object with his anamnesis data is returned")]
        public void ThenTheRequestedPersonObjectWithHisAnamnesisDataIsReturned()
        {
            Person person = (Person) _result;

            Assert.AreEqual(_person.socialSecurityNumber, person.socialSecurityNumber);
            Assert.AreEqual(_person.birthDate, person.birthDate);
            Assert.AreEqual(_person.gender, person.gender);

            Assert.AreEqual(_person.measurements[0].length, person.measurements[0].length);
            Assert.AreEqual(_person.measurements[0].weight, person.measurements[0].weight);
            Assert.AreEqual(_person.measurements[0].date, person.measurements[0].date);
        }

        [Then(@"null is returned")]
        public void ThenNullIsReturned()
        {
            Assert.IsNull(_result);
        }

        [Then(@"the new anamnesis data is added to the database")]
        public void ThenTheNewAnamnesisDataIsAddedToTheDatabase()
        {
            DataSet result = _dbDAL.GetDataSetFromDb(new StringCollection { "Measurement" });
            DataTable tbl = result.Tables[0];

            Assert.AreEqual(_socSecNr, (String)tbl.Rows[1]["SocialSecurityNumber"]);
            Assert.AreEqual(_measurement.length, (int)tbl.Rows[1]["Length"]);
            Assert.AreEqual(_measurement.weight, (int)tbl.Rows[1]["Weight"]);
            Assert.AreEqual(_measurement.date, (DateTime)tbl.Rows[1]["Date"]);
        }

        [Then(@"a list with one entry = (.*) is returned")]
        public void ThenAListWithOneEntryIsReturned(String result)
        {
            List<String> list = (List<String>) _result;

            Assert.AreEqual(result, list[0]);
        }
    }
}
