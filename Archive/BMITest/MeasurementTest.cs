using System;
using BMIExample.Models.Containers;
using NUnit.Framework;

namespace BMITest
{
    [TestFixture]
    public class MeasurementTest
    {
        private const int NORMAL_WEIGHT = 75000;
	    private const int BIT_TO_SMALL_LENGTH = 24;
	    private const int JUST_BIG_ENOUGH_LENGTH = 25;
	    private const int NORMAL_LENGTH = 180;
        private const int OTHER_NORMAL_LENGTH = 190;
        private const int LOT_TO_BIG_LENGTH = 300;
        private const int BIT_TO_BIG_LENGTH = 276;
        private const int JUST_SMALL_ENOUGH_LENGTH = 275;
        private const int LOT_TO_SMALL_LENGTH = 10;
        private const int LOT_TO_BIG_WEIGHT = 700000;
        private const int BIT_TO_BIG_WEIGHT = 600001;
        private const int JUST_SMALL_ENOUGH_WEIGHT = 600000;
        private const int LOT_TO_SMALL_WEIGHT = 200;
        private const int BIT_TO_SMALL_WEIGHT = 299;
        private const int JUST_BIG_ENOUGH_WEIGHT = 300;
        private static readonly DateTime NORMAL_DATE = new DateTime(2013, 10, 5);
        private DateTime otherDate = new DateTime(2013, 10, 10);
	
	    private Measurement _measurement;
	    private Measurement _otherMeasurement;
	    private Measurement _sameMeasurement;

        [SetUp]
        public void setUp()
        {
            _measurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
            _sameMeasurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
            otherDate = otherDate.AddMonths(DateTime.Now.Month);
            _otherMeasurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, otherDate);
 
        }

        [Test]
        public void test_Measurement_Measurement_is_created_with_given_valid_length_weight_and_date()
        {
		    Measurement measurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
		
		    Assert.AreEqual(NORMAL_LENGTH, measurement.length);
            Assert.AreEqual(NORMAL_WEIGHT, measurement.weight);
            Assert.AreEqual(NORMAL_DATE, measurement.date);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_length_greater_than_275_cm()
	    {
	        new Measurement(LOT_TO_BIG_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
	    }

        [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_lengthslighly_to_big_275_cm()
        {
            new Measurement(BIT_TO_BIG_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
        }
        
        [Test]
	    public void test_Measurement_Measurement_is_created_if_new_length_equals_275_cm()
        {
		    Measurement measurement = new Measurement(JUST_SMALL_ENOUGH_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);

		    Assert.AreEqual(JUST_SMALL_ENOUGH_LENGTH, measurement.length);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_length_smaller_than_25_cm()
	    {
	        new Measurement(LOT_TO_SMALL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
	    }

        [Test]
	    public void test_Measurement_Measurement_is_created_if_new_length_equals_25_cm()
        {
		    Measurement measurement = new Measurement(JUST_BIG_ENOUGH_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);	
		
		    Assert.AreEqual(JUST_BIG_ENOUGH_LENGTH, measurement.length);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_length_slightly_to_small()
	    {
	        new Measurement(BIT_TO_SMALL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
	    }
        
        [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_weight_greater_than_600000_gr()
        {
            new Measurement(NORMAL_LENGTH, LOT_TO_BIG_WEIGHT, NORMAL_DATE);
        }

        [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_weight_slighly_to_big()
        {
            new Measurement(NORMAL_LENGTH, BIT_TO_BIG_WEIGHT, NORMAL_DATE);
        }

        [Test]
	    public void test_Measurement_Weight_is_replaced_if_new_weight_equals_600000_gr()
        {
		    Measurement measurement = new Measurement(NORMAL_LENGTH, JUST_SMALL_ENOUGH_WEIGHT, NORMAL_DATE);

		    Assert.AreEqual(JUST_SMALL_ENOUGH_WEIGHT, measurement.weight);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_weight_smaller_than_300_gr()
	    {
	        new Measurement(NORMAL_LENGTH, LOT_TO_SMALL_WEIGHT, NORMAL_DATE);
	    }

        [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_Measurement_Exception_if_new_weight_slightlu_to_small()
        {
            new Measurement(NORMAL_LENGTH, BIT_TO_SMALL_WEIGHT, NORMAL_DATE);
        }

        [Test]
	    public void test_Measurement_Weight_is_replaced_if_new_weight_equals_300_gr()
        {
		    Measurement measurement = new Measurement(NORMAL_LENGTH, JUST_BIG_ENOUGH_WEIGHT, NORMAL_DATE);

		    Assert.AreEqual(JUST_BIG_ENOUGH_WEIGHT, measurement.weight);
	    }

        /*DateTime can never be as assigned null
        [Test] [ExpectedException(typeof(ArgumentException))]
        public void test_Measurement_Exception_if_date_null()
        {
            Measurement measurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, null);
        }*/
	
	    [Test]
	    public void test_setLengte_Length_is_replaced_if_new_lenght_valid()
        {
		    _measurement.length = OTHER_NORMAL_LENGTH;
		
		    Assert.AreEqual(OTHER_NORMAL_LENGTH, _measurement.length);
	    }
	
	    [Test]
	    public void test_setLengte_Length_is_replaced_if_new_lenght_275_cm()
        {
		    _measurement.length = JUST_SMALL_ENOUGH_LENGTH;
		
		    Assert.AreEqual(JUST_SMALL_ENOUGH_LENGTH, _measurement.length);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setLengte_Exception_if_new_length_greater_than_275_cm()
        {
		    _measurement.length = LOT_TO_BIG_LENGTH;
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setLengte_Exception_if_new_length_slightly_to_big()
        {
		    _measurement.length = BIT_TO_BIG_LENGTH;
	    }
	
	    [Test]
	    public void test_setLengte_Length_is_replaced_if_new_lenght_25_cm()
        {
		    _measurement.length = JUST_BIG_ENOUGH_LENGTH;
		
		    Assert.AreEqual(JUST_BIG_ENOUGH_LENGTH, _measurement.length);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setLengte_Exception_if_new_length_smaller_than_25_cm()
        {
		    _measurement.length = LOT_TO_SMALL_LENGTH;
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setLengte_Exception_if_new_length_equals_25_cm()
        {
		    _measurement.length = BIT_TO_SMALL_LENGTH;		
		
		    Assert.AreEqual(JUST_SMALL_ENOUGH_LENGTH, _measurement.weight);
	    }
	
	    [Test]
	    public void test_setGewicht_Weight_is_replaced_if_new_weight_valid()
        {
		    _measurement.weight = NORMAL_WEIGHT;
		
		    Assert.AreEqual(NORMAL_WEIGHT, _measurement.weight);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setGewicht_Exception_if_new_weight_greater_than_600000_gr()
	    {
	        _measurement.weight = LOT_TO_BIG_WEIGHT;
	    }
	
	    [Test] 
	    public void test_setGewicht_Weight_is_replaced_if_new_gewicht_equals_600000_gr()
        {
		    _measurement.weight = JUST_SMALL_ENOUGH_WEIGHT;
		
		    Assert.AreEqual(JUST_SMALL_ENOUGH_WEIGHT, _measurement.weight);
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setGewicht_Exception_if_new_weight_slightly_to_big()
        {
		    _measurement.weight = BIT_TO_BIG_WEIGHT;
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setGewicht_Exception_if_new_weight_smaller_than_300_gr()
        {
		    _measurement.weight = LOT_TO_SMALL_WEIGHT;
	    }
	
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setGewicht_Exception_if_new_weight_slightly_to_small()
        {
		    _measurement.weight = BIT_TO_SMALL_WEIGHT;
	    }
	
	    [Test]
	    public void test_setGewicht_Weight_is_replaced_if_new_weight_equals_300_gr()
        {
		    _measurement.weight = JUST_BIG_ENOUGH_WEIGHT;
		
		    Assert.AreEqual(JUST_BIG_ENOUGH_WEIGHT, _measurement.weight);
	    }
	
        /*DateTime can never be as assigned null
	    [Test] [ExpectedException(typeof(ArgumentException))]
	    public void test_setDate_Exception_if_no_date_is_given()
        {
		    _measurement.date = null;
	    }*/
	
	    [Test]
	    public void test_setDate_Date_is_replaced_if_new_date_is_given()
        {
		    _measurement.date = otherDate;
		
		    Assert.AreEqual(otherDate, _measurement.date);
	    }
	
	    [Test]
	    public void test_compareTo_positive_if_other_null()
        {
		    Assert.IsTrue(_measurement.CompareTo(null) > 0);
	    }

	    [Test] 
	    public void test_compareTo_negative_if_other_date_later()
        {
            Assert.IsTrue(_measurement.CompareTo(_otherMeasurement) < 0);
	    }

	    [Test]
	    public void test_compareTo_positive_if_other_date_earlier()
	    {
	        _otherMeasurement.date = new DateTime(2013, 9, 5);
            Assert.IsTrue(_measurement.CompareTo(_otherMeasurement) > 0);
	    }

	    [Test]
	    public void test_compareTo_0_if_other_if_other_date_equal()
        {
            Assert.IsTrue(_measurement.CompareTo(_sameMeasurement) == 0);
	    }
	
	    [Test]
	    public void test_equals_false_if_other_null()
        {
            Assert.IsFalse(_measurement.equals(null));
	    }

	    [Test] 
	    public void test_equals_false_if_other_date_different()
        {
            Assert.IsFalse(_measurement.equals(_otherMeasurement));
	    }

	    [Test]
	    public void test_equals_true_if_other_date_equal()
        {
            Assert.IsTrue(_measurement.equals(_sameMeasurement));
	    }
    }
}
