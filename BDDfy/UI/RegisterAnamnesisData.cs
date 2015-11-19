using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;
using UI_Ranorex.Maps;

namespace UI
{
    [TestClass]
    [Story(
        AsA = "a user",
        IWant = "to register anamnesis data of a person",
        SoThat = "the person's bmi can be calculated")]
    public class RegisterAnamnesisData
    {
        #region Variables
        public const String _LENGTH = "180";
        public const String _WEIGHT = "75000";
        public const String _DATE = "5-10-2013";

        public String _message;
        public Boolean _isLengthSet;
        public Boolean _isWeightSet;
        public Boolean _isDateSet;
        #endregion

        #region Properties
        public String mandatoryField { get; set; }
        public String errorMessage { get; set; }
        public String field { get; set; }
        public String invalidValue { get; set; }
        #endregion

        #region Specs
        [TestMethod]
        public void AMeasurementWithNewAnamnesisDataCanBeAdded()
        {
            setUp();
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => _.IWantToRegisterNewAnamnesisDataForThisPerson(), "And I want to register new anamnesis data for this person")
                .When(_ => _.IProvideAsLength("180"), "When I provide as length 180")
                .And(_ => _.IProvideAsWeight("75000"), "And I provide as weight 75000")
                .And(_ => _.IProvideAsDate("12-12-2012"), "And I provide as date 12-12-2012")
                .And(_ => _.IChooseToRegister(), "And I choose to register")
                .Then(_ => _.aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided(), "Then a new measurement is added to the anamnesis history of this person with the data provide")
                .BDDfy("A measurement with new anamnesis data can be added");
            tearDown();
        }

        [TestMethod]
        public void AnErrormessageIsGivenIfNotAllMandatoryFieldsAreProvided()
        {
            setUp();
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => _.IWantToRegisterNewAnamnesisDataForThisPerson(), "And I want to register new anamnesis data for this person")
                .When(_ => _.ILeaveAMmandatoryFieldEmpty(), "When I leave a <mandatoryField> empty")
                .And(_ => _.allOtherDataIsValid(), "And all other data is valid")
                .And(_ => _.IChooseToRegister(), "And I choose to register")
                .Then(_ => _.theErrorMessageIsGiven(), "Then the error message <errorMessage> is given")
                .WithExamples(@"
                | mandatoryField | errorMessage        |
                | Length         | Length is mandatory |
                | Weight         | Weight is mandatory |
                ")
                .BDDfy("An error message is given if not all mandatory fields are provided");
            tearDown();
        }

        [TestMethod]
        public void AnErrormessageIsGivenIfInvalidDataIsProvided()
        {
            setUp();
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => _.IWantToRegisterNewAnamnesisDataForThisPerson(), "And I want to register new anamnesis data for this person")
                .When(_ => _.IEnterAnInvalidValueInAField(), "When I enter an <invalidValue> in a <field>")
                .And(_ => _.allOtherDataIsValid(), "And all other data is valid")
                .And(_ => _.IChooseToRegister(), "And I choose to register")
                .Then(_ => _.theErrorMessageIsGiven(), "Then the error message <errorMessage> is given")
                .WithExamples(@"
                | field  | invalidValue       | errorMessage                             |
                | Length | one hundred eighty | Not a numeric length                     |
                | Length | 49                 | Length should be between 50 and 300      |
                | Weight | 1999               | Weight should be between 2000 and 700000 |
                | Weight | seven thousand     | Not a numeric weight                     |
                | Date   | 10-10-2016         | Date should not be in the future         |
                ")
                .BDDfy("An error message is given if invalid data is provided");
            tearDown();
        }

        [TestMethod]
        public void AnErrormessageIsGivenIfAMeasurementIsAlreadyRegisteredForTheCurrentDateAndTime()
        {
            setUp();
            this.Given(_ => _.anExistingPerson(), "Given an existing person")
                .And(_ => _.thePersonHasAMeasurementOn("9-9-2009"), "And the person has a measurement on 9-9-2009")
                .And(_ => _.IWantToRegisterNewAnamnesisDataForThisPerson(), "And I want to register new anamnesis data for this person")
                .When(_ => _.IProvideAsDate("9-9-2009"), "When I provide as date 9-9-2009")
                .And(_ => _.allOtherDataIsValid(), "And all other data is valid")
                .And(_ => _.IChooseToRegister(), "And I choose to register")
                .Then(_ => _.theErrorMessageIsReturned("A measurement for this moment is already registered"), "Then the error message A measurement for this moment is already registered is given")
                .BDDfy("A measurement with new anamnesis data can be added");
            tearDown();
        }
        #endregion

        #region Steps
        public void anExistingPerson()
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

        public void IWantToRegisterNewAnamnesisDataForThisPerson()
        {
            BMIUIMap.personViewMap.clickAddMeasurement();   
        }

        public void IProvideAsLength(String length)
        {
            BMIUIMap.measurementMap.setLength(length);
            _isLengthSet = true;    
        }

        public void IProvideAsWeight(String weight)
        {
            BMIUIMap.measurementMap.setWeight(weight);
            _isWeightSet = true;    
        }

        public void IProvideAsDate(String date)
        {
            BMIUIMap.measurementMap.setMeasurementDate(date);
            _isDateSet = true;   
        }

        public void IChooseToRegister()
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

        public void aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided()
        {
            Assert.IsTrue(BMIUIMap.measurementMap.getMessageText().Contains("New measurement for person with social security number "));    
        }

        public void theErrorMessageIsGiven()
        {
            Assert.AreEqual(errorMessage.Trim(), _message.Trim());   
        }

        public void ILeaveAMmandatoryFieldEmpty()
        {
            MethodInfo method = GetType().GetMethod("IProvideAs" + mandatoryField);
            method.Invoke(this, new object[] { "" });    
        }

        public void allOtherDataIsValid()
        {
            if (!_isLengthSet)
            {
                IProvideAsLength(_LENGTH);
            }

            if (!_isWeightSet)
            {
                IProvideAsWeight(_WEIGHT);
            }

            if (!_isDateSet)
            {
                IProvideAsDate(_DATE);
            }
        }

        public void IEnterAnInvalidValueInAField()
        {
            MethodInfo method = GetType().GetMethod("IProvideAs" + field);
            method.Invoke(this, new object[] { invalidValue });    
        }

        public void thePersonHasAMeasurementOn(String date)
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

        public void theErrorMessageIsReturned(String msg)
        {
            Assert.AreEqual(msg.Trim(), _message.Trim());        
        }
        #endregion

        #region Helpers
        public void setUp()
        {
            _isLengthSet = false;
            _isWeightSet = false;
            _isDateSet = false;

            Thread.Sleep(3000);
            StartIISExpressFromPath(@"D:\Elektromap\KHLimCo-op\net\WP3 Onwtikkel-implementatie onderzoek 1\BMIExample\BMIWeb", 8057);
        }

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

        public void StartIISExpressFromPath(string path, int port = 7329)
        {
            var arguments = new StringBuilder();

            arguments.Append(@"/path:""" + path + @"""");

            arguments.Append(@" /port:""" + port + @"""");

            Process.Start(new ProcessStartInfo
            {
                FileName =
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe",
                Arguments = arguments.ToString(),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            Process.Start("http://localhost:" + port);
        }

        #endregion
    }
}
