using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BMI;
using BMI.Containers;
using BMI.Def;
using BMIWeb.Controllers;
using BMIWeb.DAL;
using BMIWeb.Models.Def;
using BMIWeb.Models.WrapperModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace Unit_Mock
{
    [Binding]
    public class ControllerSteps
    {
        private static DateTime _BIRTHDATE = new DateTime(1986,5,2);
        private static DateTime _MEASUREMENTDATE = new DateTime(2010,5,2);
        private const String _SOCIALSECURITYNUMBER = "123456789";
        private static PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        private const String _LENGTH = "180";
        private const String _WEIGHT = "75000";
        
        private Mock<IBMIDAL> _BMIDALMoq;
        private BMIController _controller;
        private PersonWrapper _dataModel;
        private String _socialSecurityNumber;
        private ActionResult _result;
        private Exception _ex;

        [Given(@"a BMIController")]
        public void GivenABMIController()
        {
            _BMIDALMoq = new Mock<IBMIDAL>();
            _controller = new BMIController(_BMIDALMoq.Object);
        }

        [Given(@"a valid datamodel is provided")]
        public void GivenAValidDatamodelIsProvided()
        {
            generateValidDataModel();
        }

        [Given(@"a datamodel which is null is provided")]
        public void GivenADatamodelWhichIsNullIsProvided()
        {
            _dataModel = null;
        }

        [Given(@"the provide social security number is (.*), which is (.*)")]
        public void GivenTheProvideSocialSecurityNumberIsWhichIsNonExistent(String value, String error)
        {
            if (value == "null")
            {
                _socialSecurityNumber = null;
            }
            else
            {
                _socialSecurityNumber = value;    
            }
        }

        [When(@"i try to fetch the viewresult for the overview of registerd people")]
        public void WhenITryToFetchTheViewresultForTheOverviewOfRegisterdPeople()
        {
            _BMIDALMoq.Setup(e => e.getSocialSecurityNumberList())
                    .Returns(() =>
                    {
                        return new List<String> { "123456789" };
                    });

            try
            {
                _result = _controller.Overview();
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"i try to fetch the viewresult for adding a measurement")]
        public void WhenITryToFetchTheViewresultForAddingAMeasurement()
        {
            try
            {
                _result = _controller.AddMeasurementBis(_dataModel);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"i try to fetch the viewresult for adding a person")]
        public void WhenITryToFetchTheViewresultForAddingAPerson()
        {
            try
            {
                _result = _controller.NewPerson();
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [When(@"i try to fetch the viewresult for viewing the details of a person")]
        public void WhenITryToFetchTheViewresultForViewingTheDetailsOfAPerson()
        {
            _BMIDALMoq.Setup(e => e.getPerson(It.IsAny<String>()))
                    .Returns(() =>
                    {
                        if (String.IsNullOrEmpty(_socialSecurityNumber) || _socialSecurityNumber == "5")
                        {
                            throw new Exception();
                        }

                        return new BMI.Person(_SOCIALSECURITYNUMBER, 
                                              _BIRTHDATE, 
                                              _GENDER,
                                              new BMI.Containers.Measurement(int.Parse(_LENGTH), int.Parse(_WEIGHT), _MEASUREMENTDATE));
                    });
            try
            {
                _result = _controller.ViewDetail(_socialSecurityNumber);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [Given(@"a datamodel with valid data for a person is provided")]
        public void WhenADatamodelWithValidDataForAPersonIsProvided()
        {
            generateValidDataModel();
        }

        [When(@"i try to add the new person")]
        public void WhenITryToAddTheNewPerson()
        {
            _BMIDALMoq.Setup(e => e.addPerson(It.IsAny<BMI.Person>()))
                    .Returns(() =>
                    {
                        return modelContainsBadValue(_dataModel);
                    });

            try
            {
                _result = _controller.NewPerson(_dataModel);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [Given(@"a datamodel with invalid data for a person is provided")]
        public void WhenADatamodelWithInvalidDataForAPersonIsProvided()
        {
            _dataModel = new PersonWrapper
            {
                socialSecurityNumber = "",
                birthDate = _BIRTHDATE,
                gender = _GENDER,
                length = _LENGTH,
                weight = _WEIGHT,
                date = _MEASUREMENTDATE
            };
        }

        [Given(@"a datamodel with valid anamesis data is provided")]
        public void WhenADatamodelWithValidAnamesisDataIsProvided()
        {
            generateValidDataModel();
        }

        [When(@"i try to add the new measurement")]
        public void WhenITryToAddTheNewMeasurement()
        {
            _BMIDALMoq.Setup(e => e.addMeasurement(It.IsAny<String>(), It.IsAny<BMI.Containers.Measurement>()))
                    .Returns(() =>
                    {
                        if (_dataModel == null)
                        {
                            throw new Exception();
                        }

                        return modelContainsBadValue(_dataModel);
                    });
            try
            {
                _result = _controller.AddMeasurement(_dataModel);
            }
            catch (Exception ex)
            {
                _ex = ex;
            }
        }

        [Given(@"a datamodel with invalid anamesis data is provided")]
        public void WhenADatamodelWithInvalidAnamesisDataIsProvided()
        {
            _dataModel = new PersonWrapper
            {
                socialSecurityNumber = _SOCIALSECURITYNUMBER,
                birthDate = _BIRTHDATE,
                gender = _GENDER,
                length = "0",
                weight = _WEIGHT,
                date = _MEASUREMENTDATE
            };
        }

        [Then(@"the viewresult for the for the overview of registerd people is returned")]
        public void ThenTheViewresultForTheForTheOverviewOfRegisterdPeopleIsReturned()
        {
            ViewResult result = (ViewResult) _result;
            Assert.IsTrue(result.ViewData.ContainsKey("Title"));
            Object value;

            result.ViewData.TryGetValue("Title", out value);
            Assert.AreEqual("Persons", (String)value);

            Assert.IsTrue(result.ViewData.ContainsKey("personsList"));

            Object data;
            Assert.IsTrue(result.ViewData.TryGetValue("personsList", out data));

            List<String> output = (List<String>) data;
            Assert.AreEqual("123456789", output[0]);
        }

        [Then(@"the viewresult for adding a measurement is returned")]
        public void ThenTheViewresultForAddingAMeasurementIsReturned()
        {
            ViewResult result = (ViewResult)_result;
            Assert.IsTrue(result.ViewData.ContainsKey("Title"));

            Object value;

            result.ViewData.TryGetValue("Title", out value);
            Assert.AreEqual("New Measurement", (String)value);
            Assert.AreEqual(StateDef.ModelState.Measurement, ((PersonWrapper)result.Model).state);
        }

        [Then(@"an exception is thrown")]
        public void ThenAnExceptionIsThrown()
        {
            Assert.IsNotNull(_ex);
        }

        [Then(@"the viewresult for adding a person is returned")]
        public void ThenTheViewresultForAddingAPersonIsReturned()
        {
            ViewResult result = (ViewResult)_result;
            Assert.IsTrue(result.ViewData.ContainsKey("Title"));
            Object value;

            result.ViewData.TryGetValue("Title", out value);
            Assert.AreEqual("New Person", (String)value);

            Assert.AreEqual(StateDef.ModelState.New, ((PersonWrapper)result.Model).state);
        }

        [Then(@"the viewresult for viewing the details of a person is returned")]
        public void ThenTheViewresultForViewingTheDetailsOfAPersonIsReturned()
        {
            ViewResult result = (ViewResult)_result;
            Assert.IsTrue(result.ViewData.ContainsKey("Title"));
            Object value;

            result.ViewData.TryGetValue("Title", out value);
            Assert.AreEqual("View Person", (String)value);

            Assert.AreEqual(StateDef.ModelState.View, ((PersonWrapper)result.Model).state);
        }

        [Then(@"the viewresult contains a message indicating the person is added")]
        public void ThenTheViewresultContainsAMessageIndicatingThePersonIsAdded()
        {
            ViewResult result = (ViewResult)_result;
            Assert.IsTrue(result.ViewData.ContainsKey("Title"));
            Object value;

            result.ViewData.TryGetValue("Title", out value);
            Assert.AreEqual("New Person", (String)value);

            Assert.IsTrue(result.ViewData.ContainsKey("Message"));

            result.ViewData.TryGetValue("Message", out value);

            Assert.IsTrue(((String)value).Contains("New person"));
            Assert.IsTrue(((String)value).Contains("added"));
        }

        [Then(@"the viewresult contains an error")]
        public void ThenTheViewresultContainsAnError()
        {
            ViewResult result = (ViewResult)_result;
            Assert.IsTrue(result.ViewData.ContainsKey("Message"));
            Object value;

            result.ViewData.TryGetValue("Title", out value);
            Assert.IsTrue(((String)value).Contains("Error"));
        }

        [Then(@"the viewresult contains a message indicating the measurement is added")]
        public void ThenTheViewresultContainsAMessageIndicatingTheMeasurementIsAdded()
        {
            ViewResult result = (ViewResult)_result;
            Assert.IsTrue(result.ViewData.ContainsKey("Title"));
            Object value;

            result.ViewData.TryGetValue("Title", out value);
            Assert.AreEqual("New Measurement", (String)value);

            Assert.IsTrue(result.ViewData.ContainsKey("Message"));

            result.ViewData.TryGetValue("Message", out value);

            Assert.IsTrue(((String)value).Contains("New measurement"));
            Assert.IsTrue(((String)value).Contains("added"));
        }

        [Then(@"the viewresult contains a data error")]
        public void ThenTheViewresultContainsADataError()
        {
            ViewResult result = (ViewResult)_result;
            Assert.IsTrue(result.ViewData.ContainsKey("Message"));
            Object value;

            result.ViewData.TryGetValue("Message", out value);
            Assert.IsTrue(((String)value).Contains("Data error"));
        }


        private void generateValidDataModel()
        {
            _dataModel = new PersonWrapper
            {
                socialSecurityNumber = _SOCIALSECURITYNUMBER,
                birthDate = _BIRTHDATE,
                gender = _GENDER,
                length = _LENGTH,
                weight = _WEIGHT,
                date = _MEASUREMENTDATE
            };
        }

        private Boolean modelContainsBadValue(PersonWrapper model)
        {
            if (String.IsNullOrEmpty(model.socialSecurityNumber) || model.socialSecurityNumber == "0")
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.birthDate.ToShortDateString()) || model.birthDate.ToShortDateString() == "0")
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.length) || model.length == "0")
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.weight) || model.weight == "0")
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.date.ToShortDateString()) || model.date.ToShortDateString() == "0")
            {
                return false;
            }

            return true;
        }
    }
}
