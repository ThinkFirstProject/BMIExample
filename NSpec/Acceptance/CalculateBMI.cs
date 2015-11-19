using System;
using System.Data;
using BMI;
using BMI.Containers;
using BMI.Def;
using NSpec;

namespace Acceptance
{
    public class Variables
    {
        private Person _person;
        private double _BMI;
        private double _BMIBuf;

        public Variables()
        {
            resetParameters();
        }

        public Person person
        {
            get { return _person; }
            set { _person = value; }
        }

        public double BMI
        {
            get { return _BMI; }
            set { _BMI = value; }
        }

        public double BMIBuf
        {
            get { return _BMIBuf; }
            set { _BMIBuf = value; }
        }
        
        public void resetParameters()
        {
            _person = null;
            _BMI = 0;  
        }
    }

    public class describe_CalculateBMI:nspec
    {
        private const String _SOCSECNR = "123456789";
        private const PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        private static readonly DateTime _BIRTHDATE = new DateTime(1986, 5, 2);

        private const int _LENGTH = 180;
        private const int _WEIGHT = 75000;
        private static readonly DateTime _DATE = new DateTime(2013, 10, 5);

        #region Specs

        public void specify_The_bmi_is_calculated_based_on_the_length_and_the_weight_of_a_person()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Length", typeof(int));
            tbl.Columns.Add("Weight", typeof(int));
            tbl.Columns.Add("BMI", typeof(double));

            tbl.Rows.Add(160, 65000, 25.39);
            tbl.Rows.Add(180, 75000, 23.15);

            Variables vars = new Variables();
            foreach (DataRow row in tbl.Rows)
            {
                vars.resetParameters();

                context["Given an existing person"] = () =>
                {
                    anExistingPerson(vars);
                    it["OK"] = () => nop();
                };

                context["And a last measurement with length " + row["Length"] + " and weight " + row["Weight"]] = () =>
                {
                    aLastMeasurementWithLengthAndWeight((int)row["Length"], (int)row["Weight"], vars);
                    it["OK"] = () => nop();
                };

                context["When I choose to calculate the bmi of this person"] = () =>
                {
                    IChooseToCalculateTheBmiOfThisPerson(vars);
                    vars.BMIBuf = (double) row["BMI"];
                    it["Then the bmi is " + row["BMI"]] = () => theBmiIs(vars);
                };
            }
        }

        public void specify_The_bmi_is_calculated_based_on_the_most_recent_anamnesis_of_the_person()
        {
            Variables vars = new Variables();

            context["Given an existing person"] = () =>
            {
                anExistingPerson(vars);
                it["OK"] = () => nop();
            };

            context["And a measurement on 12-12-2012 with length 180 and weight 65000"] = () =>
            {
                aMeasurementOnWithLengthAndWeight("12-12-2012", 180, 65000, vars);
                it["OK"] = () => nop();
            };

            context["And a measurement on 12-12-2012 with length 180 and weight 65000"] = () =>
            {
                aMeasurementOnWithLengthAndWeight("12-12-2013", 180, 75000, vars);
                it["OK"] = () => nop();
            };

            context["When I choose to calculate the bmi of this person"] = () =>
            {
                IChooseToCalculateTheBmiOfThisPerson(vars);
                vars.BMIBuf = 23.15;
                it["Then the bmi is 23.15"] = () => theBmiIs(vars);
            };
        }

        public void specify_The_bmi_is_rounded_to_2_digits()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Length", typeof(int));
            tbl.Columns.Add("Weight", typeof(int));
            tbl.Columns.Add("BMI", typeof(double));

            tbl.Rows.Add(160, 65000, 25.39);
	        tbl.Rows.Add(160, 65001, 25.39);
	        tbl.Rows.Add(160, 65009, 25.39);
	        tbl.Rows.Add(180, 75000, 23.15);
            tbl.Rows.Add(180, 75009, 23.15);

            Variables vars = new Variables();
            foreach (DataRow row in tbl.Rows)
            {
                vars.resetParameters();

                context["Given an existing person"] = () =>
                {
                    anExistingPerson(vars);
                    it["OK"] = () => nop();
                };

                context["And a last measurement with length " + row["Length"] + " and weight " + row["Weight"]] = () =>
                {
                    aLastMeasurementWithLengthAndWeight((int)row["Length"], (int)row["Weight"], vars);
                    it["OK"] = () => nop();
                };

                context["When I choose to calculate the bmi of this person"] = () =>
                {
                    IChooseToCalculateTheBmiOfThisPerson(vars);
                    vars.BMIBuf = (double)row["BMI"];
                    it["Then the bmi is " + row["BMI"]] = () => theBmiIs(vars);
                };
            }
        }
        #endregion

        #region Steps
        private void theBmiIs(Variables vars)
        {
            vars.person.getBMI().should_be(vars.BMI);    
        }

        private void aMeasurementOnWithLengthAndWeight(string date, int length, int weight, Variables vars)
        {
            vars.person.addMeasurement(new Measurement(length, weight, DateTime.Parse(date)));
        }

        private void anExistingPerson(Variables vars)
        {
            vars.person = new Person(_SOCSECNR, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }
        
        private void IChooseToCalculateTheBmiOfThisPerson(Variables vars)
        {
            vars.BMI = vars.person.getBMI();
        }

        private void aLastMeasurementWithLengthAndWeight(int length, int weight, Variables vars)
        {
            vars.person.addMeasurement(new Measurement(length, weight, DateTime.Now));
        }
        #endregion

        #region Helpers
        private void nop()
        { }
        #endregion
    }
}
