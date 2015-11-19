using System;
using BMIExample.Models;
using BMIExample.Models.Containers;
using BMIExample.Models.Def;
using NUnit.Framework;

namespace BMITest
{
    [TestFixture]
    public class _personTest
    {
        private const int NORMAL_WEIGHT = 75000;
	    private const int NORMAL_LENGTH = 180;
	    private const int DIFFERENT_LENGTH = 190;
	    private const int DIFFERENT_WEIGHT = 70000;
	    private const int SAME_LENGTH = 180;
	
	    private const double NORMAL_BMI = 23.15;
	    private const double NORMAL_BMI_PAST = 21.6;

	    private const String socialSecurityNumber = "67082628015";
	    private const String differentSocialSecurityNumber = "68082628015";
	
	    private DateTime _pastDate;
	    private DateTime _birthDate;
	    private DateTime _date;
	    private DateTime _now;
	
	    private Measurement _measurementPast;
	    private Measurement _measurement;
	    private Measurement _measurementNow;

        private const PersonDef.Gender _male = PersonDef.Gender.Male;

        private Person _person;
	    private Person _personWithSameSocialSecurityNumber;
	    private Person _personWithDifferentSocialSecurityNumber;
        
        [SetUp]
        public void setUp()
        {
            _birthDate = new DateTime(1967, 8, 26); 
            _pastDate = new DateTime(1998, 10, 10); 
            _date = new DateTime(2013,10,22); 
            _now = DateTime.Now; 
            _measurementPast = new Measurement(SAME_LENGTH, DIFFERENT_WEIGHT, _pastDate);
            _measurement = new Measurement(NORMAL_LENGTH  , NORMAL_WEIGHT  , _date); 
            _measurementNow = new Measurement(DIFFERENT_LENGTH, NORMAL_WEIGHT, _now); 
            _person  = new Person(socialSecurityNumber, _birthDate, _male, _measurementPast); 
            _personWithSameSocialSecurityNumber = new Person(socialSecurityNumber, _birthDate, _male, _measurementPast);
            _personWithDifferentSocialSecurityNumber  = new Person(differentSocialSecurityNumber, _birthDate, _male, _measurementPast); 
        }

        [Test]
	    public void test_person_person_with_valid_socialsecuritynumber_birthdate_gender_and_measurement_created() 
        {
            Person person = new Person(socialSecurityNumber, _birthDate, _male, _measurement);
		
		    Assert.AreEqual(socialSecurityNumber, _person.socialSecurityNumber);
		    Assert.AreEqual(_birthDate, _person.birthDate);
		    Assert.AreEqual(_male, _person.gender);
		    Assert.AreEqual(NORMAL_BMI, person.getBMI(), 0.0);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_person_Exception_if_socialsecuritynumber_null() 
        {
		    new Person(null, _birthDate, _male, _measurement);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_person_Exception_if_socialsecuritynumber_empty() 
        {
		    new Person("", _birthDate, _male, _measurement);
	    }
	
        /*DateTime can never be null
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_person_Exception_if_birthdate_null() 
        {
		    new Person(socialSecurityNumber, null, _male, _measurement);
	    }*/
	
        /*Gender is not nullable
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_person_Exception_if_gender_null() {
		    new Person(socialSecurityNumber, _birthDate, null, _measurement);
	    }*/

	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_person_Exception_if_no_measurement() 
        {
		    new Person(socialSecurityNumber, _birthDate, _male, null);
	    }
	
	    [Test]
	    public void test_setSocialSecurityNumber_SocialSecurityNumber_replaced_when_valid_new_socialsecuritynumber() 
        {
		    _person.socialSecurityNumber = "68082628015";
		
		    Assert.AreEqual("68082628015", _person.socialSecurityNumber);
		    Assert.AreEqual(_birthDate, _person.birthDate);
		    Assert.AreEqual(_male, _person.gender);
		    Assert.AreEqual(NORMAL_BMI_PAST, _person.getBMI(), 0.0);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setSocialSecurityNumber_Exception_if_new_socialsecuritynumber_empty() 
        {
		    _person.socialSecurityNumber = "";
	    }

	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setSocialSecurityNumber_Exception_if_new_socialsecuritynumber_null() 
        {
		    _person.socialSecurityNumber = null;
	    }
	
	    [Test]
	    public void test_setBirthDate_Date_replaced_when_valid_new_date() 
        {
		    _person.birthDate = _pastDate;
		
		    Assert.AreEqual(socialSecurityNumber, _person.socialSecurityNumber);
		    Assert.AreEqual(_pastDate, _person.birthDate);
		    Assert.AreEqual(_male, _person.gender);
		    Assert.AreEqual(NORMAL_BMI_PAST, _person.getBMI(), 0.0);
	    }
	
        /*DateTime can't be null
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setBirthDate_Exception_if_new_date_null() 
        {
		    _person.setBirthDate(null);
	    }
        */

	    [Test]
	    public void test_setGender_Gender_replaced_when_valid_new_gender() 
        {
		    _person.gender = PersonDef.Gender.Female;
		
		    Assert.AreEqual(socialSecurityNumber, _person.socialSecurityNumber);
		    Assert.AreEqual(_birthDate, _person.birthDate);
		    Assert.AreEqual(PersonDef.Gender.Female, _person.gender);
		    Assert.AreEqual(NORMAL_BMI_PAST, _person.getBMI(), 0.0);
	    }

        /*Gender can't be assigned null
        [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setGender_Exception_if_new_gender_null() 
        {
		    _person.setGender(null);
	    }*/
	
	    [Test]
	    public void test_addMeasurement_Measurement_added() 
        {
		    _person.addMeasurement(_measurement);

		    Assert.AreEqual(2, _person.getNumberOfMeasurements());
		    Assert.AreEqual(NORMAL_BMI, _person.getBMI(), 0.0);
	    }

	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_addMeasurement_Exception_if_new_measurement_null() 
        {
		    _person.addMeasurement(null);
	    }

	    [Test]
	    public void test_removeMeasurement_Measurement_removed() 
        {
		    _person.addMeasurement(_measurement);
		    Assert.AreEqual(2, _person.getNumberOfMeasurements());
		    _person.removeMeasurement(_measurement);
		
		    Assert.AreEqual(1, _person.getNumberOfMeasurements());
	    }

	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_removeMeasurement_Exception_if_measurement_null() 
        {
		    _person.removeMeasurement(null);
	    }
		
	    [Test]
	    public void test_getBmi_Bmi_calculated_on_the_most_recent_measurement_from_person() 
        {
		    Assert.AreEqual(NORMAL_BMI_PAST, _person.getBMI(), 0.0);
		
		    _person.addMeasurement(_measurement);
		    Assert.AreEqual(NORMAL_BMI, _person.getBMI(), 0.0);		
	    }
	
	    [Test]
	    public void test_equals_True_if_2_persons_has_the_same_socialsecurityNumber()
        {
		    Assert.IsTrue(_person.equals(_person));
            Assert.IsTrue(_person.equals(_personWithSameSocialSecurityNumber));
	    }
	
	    [Test]
	    public void test_equals_False_if_2_persons_has_different_socialsecurityNumber()
        {
            Assert.IsFalse(_person.equals(_personWithDifferentSocialSecurityNumber));
	    }
	
	    [Test]
	    public void test_getLength_returns_length_last_measurement() 
        {
		    Assert.AreEqual(NORMAL_LENGTH, _person.getLength());
		    _person.addMeasurement(_measurementNow);
		    Assert.AreEqual(DIFFERENT_LENGTH, _person.getLength());
	    }
	
	    [Test]
	    public void test_getWeight_returns_weight_last_measurement() 
        {
		    Assert.AreEqual(DIFFERENT_WEIGHT, _person.getWeight());
		    _person.addMeasurement(_measurementNow);
		    Assert.AreEqual(NORMAL_WEIGHT, _person.getWeight());
	    }
	
	    [Test]
	    public void test_getLastMeasurementDate_returns_date_last_measurement() 
        {
		    Assert.AreEqual(_pastDate, _person.getLastMeasurementDate());
		    _person.addMeasurement(_measurementNow);
		    Assert.AreEqual(_now, _person.getLastMeasurementDate());
	    }

        
    }
}
