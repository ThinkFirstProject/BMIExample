using System;
using BMI;
using BMI.Containers;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Specflow_Acceptance
{
    [Binding]
    public class Common
    {
        [Given(@"a valid user")]
        public void GivenAValidUser()
        {
            ScenarioContext.Current.Add("User", new Person("1", new DateTime(1986, 5, 2), PersonDef.Gender.Male, new Measurement(180, 75000, DateTime.Now)));
        }

        [Then(@"an error is returned containing the message (.*)")]
        public void ThenAnErrorIsReturnedContainingTheMessageInvalidLength(String message)
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Error"));
            Exception error = ScenarioContext.Current.Get<Exception>("Error");
            Assert.AreEqual(message, error.Message);
        }
    }
}
