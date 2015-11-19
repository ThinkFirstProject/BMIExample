using System;
using Moq;
using TechTalk.SpecFlow;
using BMIWeb.DAL;

namespace Specflow_Service
{
    [Binding]
    public class DBServiceUnitSteps
    {
        private BMIDAL _DAL;
        private Mock<IBMIDAL> _DALMock;

        [Given(@"a database service\(unit\)")]
        public void GivenADatabaseServiceUnit()
        {
            _DALMock = new Mock<IBMIDAL>();
        }

        [Given(@"a list of new people is provided\(unit\)")]
        public void GivenAListOfNewPeopleIsProvidedUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"a list of people is already saved\(unit\)")]
        public void GivenAListOfPeopleIsAlreadySavedUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"a list of people is provided which is null\(unit\)")]
        public void GivenAListOfPeopleIsProvidedWhichIsNullUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the database is loaded with one person")]
        public void GivenTheDatabaseIsLoadedWithOnePerson()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"i try to save the list of people to the database\(unit\)")]
        public void WhenITryToSaveTheListOfPeopleToTheDatabaseUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"i try to save the unchanged list of people to the database\(unit\)")]
        public void WhenITryToSaveTheUnchangedListOfPeopleToTheDatabaseUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"i try to retrieve the list of people")]
        public void WhenITryToRetrieveTheListOfPeople()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the list is saved wit no errors\(unit\)")]
        public void ThenTheListIsSavedWitNoErrorsUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"no updates are performed\(unit\)")]
        public void ThenNoUpdatesArePerformedUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"an invalid argument exception is thrown\(unit\)")]
        public void ThenAnInvalidArgumentExceptionIsThrownUnit()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a list of people is returned, containing (.*) person")]
        public void ThenAListOfPeopleIsReturnedContainingPerson(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
