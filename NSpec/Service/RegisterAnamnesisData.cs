using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BMI;
using BMI.Containers;
using BMI.Def;
using NSpec;

namespace Service
{
    public class Variables
    {
        private Person _person;
        private int _length;
        private int _weight;
        private DateTime _date;
        private Exception _ex;

        public Variables()
        {
            resetParameters();    
        }

        public Person person
        {
            get { return _person; }
            set { _person = value; }
        }

        public int length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Exception ex
        {
            get { return _ex; }
            set { _ex = value; }
        }

        public void resetParameters()
        {
            _person = null;
            _length = 0;
            _weight = 0;
            _date = new DateTime();
            _ex = null;   
        }
    }

    public class describe_RegisterAnamnesisData:nspec
    {
        public const String _SOCSECNR = "123456789";
        public const PersonDef.Gender _GENDER = PersonDef.Gender.Male;
        public static readonly DateTime _BIRTHDATE = new DateTime(1986, 5, 2);

        public const int _LENGTH = 180;
        public const int _WEIGHT = 75000;
        public static readonly DateTime _DATE = new DateTime(2013, 10, 5);

        #region Specs
        public void specify_A_measurement_with_new_anamnesis_data_can_be_added()
        {
            Variables vars = new Variables();

            context["Given an existing person"] = () =>
            {
                anExistingPerson(vars);
                it["OK"] = () => nop();
            };

            context["When I provide as length 180"] = () =>
            {
                IProvideAsLength("180", vars);
                it["OK"] = () => nop();
            };

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

            context["And I try to add the measurement to this person"] = () =>
            {
                ITryToAddTheMeasurementToThisPerson(vars);
                it["Then a new measurement is added to the anamnesis history of this person with the data provided"] = () => aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided(vars);
            };    
        }

        public void specify_An_error_message_is_given_when_any_field_of_the_anamnesis_data_is_invalid()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Field", typeof(String));
            tbl.Columns.Add("InvalidValue", typeof(String));

            tbl.Rows.Add("Length", "49");
            tbl.Rows.Add("Weight", "299 ");
            tbl.Rows.Add("Date", "10-10-3016");

            Variables vars = new Variables();
            foreach (DataRow row in tbl.Rows)
            {
                vars.resetParameters();

                context["Given an existing person"] = () =>
                {
                    anExistingPerson(vars);
                    it["OK"] = () => nop();
                };

                context["When I provide " + row["InvalidValue"] + " as " + row["Field"]] = () =>
                {
                    IProvideAs((String)row["Field"], (String)row["InvalidValue"], vars);
                    it["OK"] = () => nop();
                };

                context["And all other data is valid"] = () =>
                {
                    allOtherDataIsValid(vars);
                    it["OK"] = () => nop();
                };

                context["And I try to add the measurement to this person"] = () =>
                {
                    ITryToAddTheMeasurementToThisPerson(vars);
                    it["Then an error message is given"] = () => anErrorMessageIsGiven(vars);
                };

            }
        }

        public void specify_An_error_message_is_given_if_a_measurement_is_already_registered_for_the_current_date_and_time()
        {
            Variables vars = new Variables();

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

            context["When I provide as date 9-9-2009"] = () =>
            {
                IProvideAsDate("9-9-2009", vars);
                it["OK"] = () => nop();
            };

            context["And all other data is valid"] = () =>
            {
                allOtherDataIsValid(vars);
                it["OK"] = () => nop();
            };

            context["And I try to add the measurement to this person"] = () =>
            {
                ITryToAddTheMeasurementToThisPerson(vars);
                it["Then an error message is given"] = () => anErrorMessageIsGiven(vars);
            };        
        }
        #endregion

        #region Steps
        public void anExistingPerson(Variables vars)
        {
            vars.person = new Person(_SOCSECNR, _BIRTHDATE, _GENDER, new Measurement(_LENGTH, _WEIGHT, _DATE));
        }

        public void IProvideAsLength(String value, Variables vars)
        {
            vars.length = int.Parse(value);
        }

        public void IProvideAsWeight(String value, Variables vars)
        {
            vars.weight = int.Parse(value);
        }

        public void IProvideAsDate(string value, Variables vars)
        {
            vars.date = DateTime.Parse(value);
        }

        public void ITryToAddTheMeasurementToThisPerson(Variables vars)
        {
            try
            {
                vars.person.addMeasurement(new Measurement(vars.length, vars.weight, vars.date));
            }
            catch (Exception ex)
            {
                vars.ex = ex;
            }
        }

        public void aNewMeasurementIsAddedToTheAnamnesisHistoryOfThisPersonWithTheDataProvided(Variables vars)
        {
            vars.person.measurements.Count.should_be(2);
            vars.person.measurements[1].length.should_be(vars.length);
            vars.person.measurements[1].weight.should_be(vars.weight);

            (vars.person.measurements.Exists(e => e.date.Day == vars.date.Day &&
                                                           e.date.Month == vars.date.Month &&
                                                           e.date.Year == vars.date.Year)).should_be(true);
        }

        public void anErrorMessageIsGiven(Variables vars)
        {
            vars.ex.should_not_be_null();
            (String.IsNullOrEmpty(vars.ex.Message)).should_be(false);
        }

        public void allOtherDataIsValid(Variables vars)
        {
            if (vars.length == 0)
            {
                vars.length = _LENGTH;
            }

            if (vars.weight == 0)
            {
                vars.weight = _WEIGHT;
            }

            if (vars.date.Year == 1)
            {
                vars.date = new DateTime(_DATE.Year, _DATE.Month, _DATE.Day + 1);
            }
        }

        public void IProvideAs(String field, String value, Variables vars)
        {
            MethodInfo method = GetType().GetMethod("IProvideAs" + field);
            method.Invoke(this, new object[] { value, vars});
        }

        public void thePersonHasAMeasurementOn(string date, Variables vars)
        {
            vars.person.addMeasurement(new Measurement(_LENGTH, _WEIGHT, DateTime.Parse(date)));
        }
        #endregion

        #region Helpers
        private void nop()
        { }
        #endregion
    }
}
