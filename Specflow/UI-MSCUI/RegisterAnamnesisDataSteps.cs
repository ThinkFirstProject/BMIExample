using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using BMI.Def;
using Specflow_UI_MSCUI.Map;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UI_MSCUI
{
    [Binding]
    public class RegisterAnamnesisDataSteps
    {
        private const String _LENGTH = "180";
        private const String _WEIGHT = "75000";
        private const String _DATE = "5-10-2013";

        private String _message;
        private Boolean _isLengthSet;
        private Boolean _isWeightSet;
        private Boolean _isDateSet;

        [BeforeScenario]
        public void setUp()
        {
            _isLengthSet = false;
            _isWeightSet = false;
            _isDateSet = false;

            Thread.Sleep(3000);
            StartIISExpressFromPath(@"D:\Elektromap\KHLimCo-op\net\WP3 Onwtikkel-implementatie onderzoek 1\BMIExample\BMIWeb", 8057);
        }

        [AfterScenario]
        public void tearDown()
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + "taskkill /IM iisexpress.exe ");
            Process proc = new Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();

            procStartInfo = new ProcessStartInfo("cmd", "/c " + "taskkill /IM iexplore.exe");
            proc = new Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();
        }

        [Given(@"an existing person")]
        public void GivenAnExistingPerson()
        {
            BMIUIMap.BMIStartMap.clickNewPerson();
            BMIUIMap.newPersonMap.setSocialSecurityNumber("123456789");
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

            BMIUIMap.BMIStartMap.clickHyperLinkPerson("123456789");
        }

        [Given(@"I want to register new anamnesis data for this person")]
        public void GivenIWantToRegisterNewAnamnesisDataForThisPerson()
        {
            BMIUIMap.personViewMap.clickAddMeasurement();
        }

        [Given(@"the person has a measurement on (.*)")]
        public void GivenThePersonHasAMeasurementOn(String date)
        {
            BMIUIMap.personViewMap.clickAddMeasurement();

            BMIUIMap.measurementMap.setLength(_LENGTH);
            BMIUIMap.measurementMap.setWeight(_WEIGHT);
            BMIUIMap.measurementMap.setMeasurementDate(date);
            BMIUIMap.measurementMap.clickAddMeasurement();
            
            Assert.IsFalse(String.IsNullOrEmpty(BMIUIMap.newPersonMap.getMessageText()));

            BMIUIMap.measurementMap.clickCancel();

            BMIUIMap.BMIStartMap.clickHyperLinkPerson("123456789");
        }

        [When(@"I provide as length (.*)")]
        public void WhenIProvideAsLength(String length)
        {
            BMIUIMap.measurementMap.setLength(length);
            _isLengthSet = true;
        }

        [When(@"I provide as weight (.*)")]
        public void WhenIProvideAsWeight(String weight)
        {
            BMIUIMap.measurementMap.setWeight(weight);
            _isWeightSet = true;
        }

        [When(@"I provide as date (.*)")]
        public void WhenIProvideAsDate(String date)
        {
            BMIUIMap.measurementMap.setMeasurementDate(date);
            _isDateSet = true;
        }

        [When(@"I choose to register")]
        public void WhenIChooseToRegister()
        {
            BMIUIMap.personViewMap.clickAddMeasurement();

            if (String.IsNullOrEmpty(BMIUIMap.newPersonMap.getErrorText()))
            {
                _message = BMIUIMap.newPersonMap.getMessageText();
            }
            else
            {
                _message = BMIUIMap.newPersonMap.getErrorText();
            }
        }

        [When(@"I leave a ""(.*)"" empty")]
        public void WhenILeaveAEmpty(string field)
        {
            MethodInfo method = GetType().GetMethod("WhenIProvideAs" + field);
            method.Invoke(this, new object[] { "" });   
        }

        [When(@"I enter an ""(.*)"" in a ""(.*)""")]
        public void WhenIEnterAnInA(string invalidValue, string field)
        {
            MethodInfo method = GetType().GetMethod("WhenIProvideAs" + field);
            method.Invoke(this, new object[] { invalidValue });
        }

        [When(@"all other data is valid")]
        public void WhenAllOtherDataIsValid()
        {
            if (!_isLengthSet)
            {
                WhenIProvideAsLength(_LENGTH);   
            }

            if (!_isWeightSet)
            {
                WhenIProvideAsWeight(_WEIGHT);
            }

            if (!_isDateSet)
            {
                WhenIProvideAsDate(_DATE);
            }
        }

        [Then(@"a new measurement is added to the anamnesis history of this person with the data provided")]
        public void ThenANewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided()
        {
            Assert.IsTrue(BMIUIMap.measurementMap.getMessageText().Contains("New measurement for person with social security number "));
        }

        [Then(@"the error message ""(.*)"" is given")]
        public void ThenTheErrorMessageIsGiven(string msg)
        {
            Assert.AreEqual(msg.Trim(), _message.Trim());
        }

        public void StartIISExpressFromPath(string path, int port = 7329)
        {
            var arguments = new StringBuilder();

            arguments.Append(@"/path:""" + path + @"""");

            arguments.Append(@" /port:""" + port + @"""");

            Process.Start(new ProcessStartInfo()

            {
                FileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe",
                Arguments = arguments.ToString(),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            Process.Start("http://localhost:" + port);
        }
    }
}
