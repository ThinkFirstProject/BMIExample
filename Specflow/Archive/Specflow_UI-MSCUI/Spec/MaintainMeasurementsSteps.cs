using System;
using System.Threading;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specflow_UI_MSCUI.Map;
using TechTalk.SpecFlow;

namespace Specflow_UI_MSCUI.Spec
{
    [Binding]
    public class MaintainMeasurementDataOfAUserSteps
    {
        [Given(@"the measurement screen is shown")]
        public void GivenTheMeasurementScreenIsShown()
        {
            BMIUIMap.personViewMap.clickAddMeasurement();
            
        }

        [Given(@"I provide valid measurement data")]
        public void GivenIProvideValidMeasurementData()
        {
            BMIUIMap.measurementMap.setLength("185");
            BMIUIMap.measurementMap.setWeight("65000");
            BMIUIMap.measurementMap.setMeasurementDate(DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year);
        }

        [When(@"I try to add the new measurement")]
        public void WhenITryToAddTheNewMeasurement()
        {
            BMIUIMap.measurementMap.clickAddMeasurement();
            
            if (String.IsNullOrEmpty(BMIUIMap.newPersonMap.getErrorText()))
            {
                ScenarioContext.Current.Add("Error", BMIUIMap.newPersonMap.getMessageText());
            }
            else
            {
                ScenarioContext.Current.Add("Error", BMIUIMap.newPersonMap.getErrorText());
            }
        }

        [Then(@"the new measurement is added to my BMI history")]
        public void ThenTheNewMeasurementIsAddedToMyBMIHistory()
        {
            Assert.IsTrue(BMIUIMap.measurementMap.getMessageText().Contains("New measurement for person with social security number "));
        }

        [Given(@"I provide data which is invalid")]
        public void GivenIProvideDataWhichIsInvalid(Table tbl)
        {
            BMIUIMap.measurementMap.setLength(tbl.Rows[0]["Length"]);
            BMIUIMap.measurementMap.setWeight(tbl.Rows[0]["Weight"]);
            BMIUIMap.measurementMap.setMeasurementDate(tbl.Rows[0]["Date"]);
        }
        
        [Given(@"a valid user which has a valid measurement")]
        public void GivenAValidUserWhichHasAValidMeasurement()
        {
            BMIUIMap.BMIStartMap.clickNewPerson();
            BMIUIMap.newPersonMap.setSocialSecurityNumber("1");
            BMIUIMap.newPersonMap.setGender(PersonDef.Gender.Male.ToString());

            DateTime date = new DateTime(1986, 5, 2);
            BMIUIMap.newPersonMap.setBirthDate(date.Day + "-" + date.Month + "-" + date.Year);
            BMIUIMap.newPersonMap.setLength("180");
            BMIUIMap.newPersonMap.setWeight("75000");
            date = DateTime.Now;
            BMIUIMap.newPersonMap.setMeasurementDate(date.Day + "-" + date.Month + "-" + date.Year);

            BMIUIMap.newPersonMap.clickOK();

            
            Assert.IsFalse(String.IsNullOrEmpty(BMIUIMap.newPersonMap.getMessageText()));

            BMIUIMap.newPersonMap.clickCancel();
            

            BMIUIMap.BMIStartMap.clickHyperLinkPerson("1");
            
        }
    }
}
