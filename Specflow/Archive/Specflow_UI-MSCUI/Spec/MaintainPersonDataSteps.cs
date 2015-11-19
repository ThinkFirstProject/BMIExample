using System;
using System.Threading;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specflow_UI_MSCUI.Map;
using TechTalk.SpecFlow;

namespace Specflow_UI_MSCUI.Spec
{
    [Binding]
    public class MaintainingThePersonalDataOfAUserSteps
    {
        [Given(@"the new person page")]
        public void GivenTheNewPersonPage()
        {
            BMIUIMap.BMIStartMap.clickNewPerson();
        }
        
        [Given(@"valid personal data is provided")]
        public void GivenValidPersonalDataIsProvided()
        {
            BMIUIMap.newPersonMap.setSocialSecurityNumber("1");
            BMIUIMap.newPersonMap.setGender(PersonDef.Gender.Male.ToString());

            DateTime birthDate = new DateTime(1986, 5, 2);
            BMIUIMap.newPersonMap.setBirthDate(birthDate.Day + "-" + birthDate.Month + "-" + birthDate.Year);
        }

        [Given(@"a valid starting measurement is provided")]
        public void GivenAValidStartingMeasurementIsProvided()
        {
            BMIUIMap.newPersonMap.setLength("180");
            BMIUIMap.newPersonMap.setWeight("75000");
            BMIUIMap.newPersonMap.setMeasurementDate(DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year);
        }

        [Given(@"an invalid first measurement is provided")]
        public void GivenAnInvalidFirstMeasurementIsProvided(Table tbl)
        {
            BMIUIMap.newPersonMap.setLength(tbl.Rows[0]["Length"]);
            BMIUIMap.newPersonMap.setWeight(tbl.Rows[0]["Weight"]);
            BMIUIMap.newPersonMap.setMeasurementDate(tbl.Rows[0]["Date"]);
        }
        
        [Given(@"personal data is provided which is invalid")]
        public void GivenPersonalDataIsProvidedWhichIsInvalid(Table table)
        {
            String socialSecNumber;

            if (table.Rows[0]["Social security number"] == "null")
            {
                socialSecNumber = null;
            }
            else
            {
                socialSecNumber = table.Rows[0]["Social security number"];
            }
            
            BMIUIMap.newPersonMap.setSocialSecurityNumber(socialSecNumber);
            BMIUIMap.newPersonMap.setGender(table.Rows[0]["Gender"]);
            BMIUIMap.newPersonMap.setBirthDate(table.Rows[0]["Birthdate"]);
        }
        
        [When(@"i try to generate a new user")]
        public void WhenITryToGenerateANewUser()
        {
            BMIUIMap.newPersonMap.clickOK();

            

            if (String.IsNullOrEmpty(BMIUIMap.newPersonMap.getErrorText()))
            {
                ScenarioContext.Current.Add("Error", BMIUIMap.newPersonMap.getMessageText());    
            }
            else
            {
                ScenarioContext.Current.Add("Error", BMIUIMap.newPersonMap.getErrorText());
            }
        }
        
        [Then(@"the new user is generated")]
        public void ThenTheNewUserIsGenerated()
        {
            Assert.IsTrue(BMIUIMap.measurementMap.getMessageText().Contains("New person with social security number "));
        }
    }
}
