using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using BMI.Def;
using NSpec;
using UI_Ranorex.Maps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UI
{
    public class Variables
    {
        private String _message;
        private Boolean _isLengthSet;
        private Boolean _isWeightSet;
        private Boolean _isDateSet;

        public Variables()
        {
            resetParameters();
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        public bool isLengthSet
        {
            get { return _isLengthSet; }
            set { _isLengthSet = value; }
        }

        public bool isWeightSet
        {
            get { return _isWeightSet; }
            set { _isWeightSet = value; }
        }

        public bool isDateSet
        {
            get { return _isDateSet; }
            set { _isDateSet = value; }
        }

        public void resetParameters()
        {
            message = "";
            isLengthSet = false;
            isWeightSet = false;
            isDateSet = false;
        }
    }

    public class describe_RegisterAnamnesisData : nspec
    {
        private const String _LENGTH = "180";
        private const String _WEIGHT = "75000";
        private const String _DATE = "5-10-2013";

        #region Specs
        public void specify_A_measurement_with_new_anamnesis_data_can_be_added()
        {
            Variables vars = new Variables();

            setUp(vars);
            context["Given an existing person"] = () =>
            {
                anExistingPerson(vars);
                it["OK"] = () => nop();
            };

            context["And I want to register new anamnesis data for this person"] = () =>
            {
                IWantToRegisterNewAnamnesisDataForThisPerson(vars);
                it["OK"] = () => nop();
            };

            context["When I provide as length 180"] = () =>
            {
                IProvideAsLength("180", vars);

                context["And I provide as weight 75000"] = () =>
                {
                    IProvideAsWeight("75000", vars);
                    it["OK"] = () => nop();
                };

                context["And I provide as date 12-12-2012"] = () =>
                {
                    IProvideAsDate("12-12-2012", vars);
                    it["OK"] = () => nop();
                };

                context["And I choose to register"] = () =>
                {
                    IChooseToRegister(vars);
                    it["Then a new measurement is added to the anamnesis history of this person with the data provide"] = () => aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided(vars);
                };
            };
            tearDown();
        }

        public void specify_An_error_message_is_given_if_not_all_mandatory_fields_are_provided()
        {
            Variables vars = new Variables();

            DataTable tbl = new DataTable();
            tbl.Columns.Add("mandatoryField", typeof(String));
            tbl.Columns.Add("errorMessage", typeof(String));

            tbl.Rows.Add("Length", "Length is mandatory");
            tbl.Rows.Add("Weight", "Weight is mandatory");

            foreach (DataRow row in tbl.Rows)
            {
                setUp(vars);
                context["Given an existing person"] = () =>
                {
                    anExistingPerson(vars);
                    it["OK"] = () => nop();
                };

                context["And I want to register new anamnesis data for this person"] = () =>
                {
                    IWantToRegisterNewAnamnesisDataForThisPerson(vars);
                    it["OK"] = () => nop();
                };

                context["When I leave a " + row["mandatoryField"] + " empty"] = () =>
                {
                    ILeaveAMmandatoryFieldEmpty((String)row["mandatoryField"], vars);

                    context["And all other data is valid"] = () =>
                    {
                        allOtherDataIsValid(vars);
                        it["OK"] = () => nop();
                    };

                    context["And I choose to register"] = () =>
                    {
                        IChooseToRegister(vars);
                        it["Then the error message " + (String)row["errorMessage"] + " is given"] = () => theErrorMessageIsGiven((String)row["errorMessage"], vars);
                    };
                };
                tearDown();
            }
        }

        public void specify_An_error_message_is_given_if_invalid_data_is_provided()
        {
            Variables vars = new Variables();


            DataTable tbl = new DataTable();
            tbl.Columns.Add("field", typeof(String));
            tbl.Columns.Add("invalidValue", typeof(String));
            tbl.Columns.Add("errorMessage", typeof(String));

            tbl.Rows.Add("Length", "one hundred eighty", "Not a numeric length");
            tbl.Rows.Add("Length", "49", "Length should be between 50 and 300");
            tbl.Rows.Add("Weight", "1999", "Weight should be between 2000 and 700000");
            tbl.Rows.Add("Weight", "seven thousand", "Not a numeric weight");
            tbl.Rows.Add("Date", "10-10-2016", "Date should not be in the future");

            foreach (DataRow row in tbl.Rows)
            {
                setUp(vars);
                context["Given an existing person"] = () =>
                {
                    anExistingPerson(vars);
                    it["OK"] = () => nop();
                };

                context["And I want to register new anamnesis data for this person"] = () =>
                {
                    IWantToRegisterNewAnamnesisDataForThisPerson(vars);
                    it["OK"] = () => nop();
                };

                context["When I enter an " + (String)row["invalidValue"] + " in a " + (String)row["field"]] = () =>
                {
                    IEnterAnInvalidValueInAField((String)row["field"], (String)row["invalidValue"], vars);

                    context["And all other data is valid"] = () =>
                    {
                        allOtherDataIsValid(vars);
                        it["OK"] = () => nop();
                    };

                    context["And I choose to register"] = () =>
                    {
                        IChooseToRegister(vars);
                        it["Then the error message " + (String)row["errorMessage"] + " is given"] = () => theErrorMessageIsGiven((String)row["errorMessage"], vars);
                    };
                };
                tearDown();
            }
        }

        public void specify_An_error_message_is_given_if_a_measurement_is_already_registered_for_the_current_date_and_time()
        {
            Variables vars = new Variables();

            setUp(vars);
            context["Given an existing person"] = () =>
            {
                anExistingPerson(vars);
                it["OK"] = () => nop();
            };

            context["And the person has a measurement on 9-9-2009"] = () =>
            {
                thePersonHasAMeasurementOn("9-9-2009", vars);
                it["OK"] = () => nop();
            };

            context["And I want to register new anamnesis data for this person"] = () =>
            {
                IWantToRegisterNewAnamnesisDataForThisPerson(vars);
                it["OK"] = () => nop();
            };

            context["When I provide as date 9-9-2009"] = () =>
            {
                IProvideAsDate("9-9-2009", vars);

                context["And all other data is valid"] = () =>
                {
                    allOtherDataIsValid(vars);
                    it["OK"] = () => nop();
                };

                context["And I choose to register"] = () =>
                {
                    IChooseToRegister(vars);
                    it["Then the error message A measurement for this moment is already registered is given"] = () => theErrorMessageIsGiven("A measurement for this moment is already registered", vars);
                };
            };
            tearDown();
        }
        #endregion

        #region Steps
        public void anExistingPerson(Variables vars)
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

        public void IWantToRegisterNewAnamnesisDataForThisPerson(Variables vars)
        {
            BMIUIMap.personViewMap.clickAddMeasurement();
        }

        public void IProvideAsLength(String length, Variables vars)
        {
            BMIUIMap.measurementMap.setLength(length);
            vars.isLengthSet = true;
        }

        public void IProvideAsWeight(String weight, Variables vars)
        {
            BMIUIMap.measurementMap.setWeight(weight);
            vars.isWeightSet = true;
        }

        public void IProvideAsDate(String date, Variables vars)
        {
            BMIUIMap.measurementMap.setMeasurementDate(date);
            vars.isDateSet = true;
        }

        public void IChooseToRegister(Variables vars)
        {
            BMIUIMap.personViewMap.clickAddMeasurement();

            if (String.IsNullOrEmpty(BMIUIMap.newPersonMap.getErrorText()))
            {
                vars.message = BMIUIMap.newPersonMap.getMessageText();
            }
            else
            {
                vars.message = BMIUIMap.newPersonMap.getErrorText();
            }
        }

        public void aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided(Variables vars)
        {
            Assert.IsTrue(BMIUIMap.measurementMap.getMessageText().Contains("New measurement for person with social security number "));
        }

        public void theErrorMessageIsGiven(String errorMessage, Variables vars)
        {
            Assert.AreEqual(errorMessage.Trim(), vars.message.Trim());
        }

        public void ILeaveAMmandatoryFieldEmpty(String mandatoryField, Variables vars)
        {
            MethodInfo method = GetType().GetMethod("IProvideAs" + mandatoryField);
            method.Invoke(this, new object[] { "", vars });
        }

        public void allOtherDataIsValid(Variables vars)
        {
            if (!vars.isLengthSet)
            {
                IProvideAsLength(_LENGTH, vars);
            }

            if (!vars.isWeightSet)
            {
                IProvideAsWeight(_WEIGHT, vars);
            }

            if (!vars.isDateSet)
            {
                IProvideAsDate(_DATE, vars);
            }
        }

        public void IEnterAnInvalidValueInAField(String field, String invalidValue, Variables vars)
        {
            MethodInfo method = GetType().GetMethod("IProvideAs" + field);
            method.Invoke(this, new object[] { invalidValue, vars });
        }

        public void thePersonHasAMeasurementOn(String date, Variables vars)
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

        #endregion

        #region Helpers
        public void setUp(Variables vars)
        {
            vars.resetParameters();
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

        private void nop()
        { }
        #endregion
    }
}
