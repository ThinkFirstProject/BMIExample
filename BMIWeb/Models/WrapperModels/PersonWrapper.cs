using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using BMI;
using BMI.Def;
using BMIWeb.Models.Def;

namespace BMIWeb.Models.WrapperModels
{
    public class PersonWrapper
    {
        private String _socialSecurityNumber;
        private DateTime _birthDate;
        private PersonDef.Gender _gender;
        private DateTime _date;
        private String _length;
        private String _weight;
        private double _bmi;
        private StateDef.ModelState _state;

        private bool _socialSecurityNumberVisible;
        private bool _birthDateVisible;
        private bool _genderVisible;
        private bool _bmiVisible;
        
        public static IEnumerable<SelectListItem> possibleGenders
        {
            get
            {
                List<String> genderList = Enum.GetNames(typeof(PersonDef.Gender)).ToList();
                
                List<SelectListItem> result = new List<SelectListItem>();

                foreach (String gender in genderList)
                {
                    result.Add(new SelectListItem { Value = gender, Selected = false, Text = gender });  
                }

                if (result.Count > 0)
                {
                    result[0].Selected = true;
                }

                return result;
            }
        }

        [Required(ErrorMessage="Social security number should not be empty")]
        public string socialSecurityNumber
        {
            get
            {
                return _socialSecurityNumber;
            }
            set
            {
                _socialSecurityNumber = value;
            }
        }

        [Required(ErrorMessage = "Birthdate should not be empty")]
        public DateTime birthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        public PersonDef.Gender gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        
        
        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        [Required(ErrorMessage = "Length is mandatory")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Not a numeric length")]
        public String length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        [Required(ErrorMessage = "Weight is mandatory")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Not a numeric weight")]
        public String weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public double bmi
        {
            get
            {
                return _bmi;
            }
            set
            {
                _bmi = value;
            }
        }

        public StateDef.ModelState state
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                modifyVisibleFields();
            }
        }

        private void modifyVisibleFields()
        {
            switch (_state)
            {
                case StateDef.ModelState.New:
                    _socialSecurityNumberVisible = true;
                    _birthDateVisible = true;
                    _genderVisible = true;
                    _bmiVisible = false;
                    break;
                case StateDef.ModelState.View:
                    _socialSecurityNumberVisible = true;
                    _birthDateVisible = true;
                    _genderVisible = true;
                    _bmiVisible = true;
                    break;
                case StateDef.ModelState.Measurement:
                    _socialSecurityNumberVisible = false;
                    _birthDateVisible = false;
                    _genderVisible = false;
                    _bmiVisible = false;
                    break;
            }
        }

        public bool socialSecurityNumberVisible
        {
            get
            {
                return _socialSecurityNumberVisible;
            }
        }

        public bool birthDateVisible
        {
            get
            {
                return _birthDateVisible;
            }
        }

        public bool genderVisible
        {
            get
            {
                return _genderVisible;
            }
        }
        
        public bool bmiVisible
        {
            get
            {
                return _bmiVisible;
            }
        }

        public void loadPersonData(Person data)
        {
            _socialSecurityNumber = data.socialSecurityNumber;
            _birthDate = data.birthDate;
            _gender = data.gender;

            _length = data.getLength().ToString(CultureInfo.InvariantCulture);
            _weight = data.getWeight().ToString(CultureInfo.InvariantCulture);
            _date = data.getLastMeasurementDate();

            _bmi = data.getBMI();
        }
    }
}