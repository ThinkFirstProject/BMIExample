using System;
using BMI.Containers;
using NSpec;

namespace NSpec_Acceptance.Specs
{
    public class MeasurementSpec : nspec
    {
        private const int NORMAL_WEIGHT = 75000;
        private const int NORMAL_LENGTH = 180;
        private const int BIT_TO_SMALL_LENGTH = 24;
	    private const int JUST_BIG_ENOUGH_LENGTH = 25;
        private const int LOT_TO_BIG_LENGTH = 300;
        private static readonly DateTime NORMAL_DATE = new DateTime(2013, 10, 5);

        private Measurement _measurement;

        void before_op()
        {
            _measurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
        }

        public void Measurement_is_created_with_given_valid_length_weight_and_date()
        {
            Measurement measurement = new Measurement(NORMAL_LENGTH, NORMAL_WEIGHT, NORMAL_DATE);
            
            specify = () => measurement.length.should_be(NORMAL_LENGTH);
            specify = () => measurement.weight.should_be(NORMAL_WEIGHT);
            specify = () => measurement.date.should_be(NORMAL_DATE);
        }

        public void Measurement_is_created_with_length_greater_than_275_cm()
        {
            it["Throws an argument exception"] = expect<ArgumentException>(() => new Measurement(LOT_TO_BIG_LENGTH, NORMAL_WEIGHT, NORMAL_DATE));
        }

        public void Testing_setLength_method_valid_length()
        {
            before = () => before_op();

            context["Length is changed with other valid length"] = () =>
            {
                act = () => _measurement.length = JUST_BIG_ENOUGH_LENGTH;
                it["Is updated with the new value"] = () => _measurement.length.should_be(JUST_BIG_ENOUGH_LENGTH);
            };
        }

        public void Testing_setLength_method_invalid_length()
        {
            before = () => before_op();

            context["Length is changed with other invalid length"] = () =>
            {
                it["Throws an exception"] = expect<ArgumentException>(() => _measurement.length = BIT_TO_SMALL_LENGTH);
                it["and the value is not changed"] = () => _measurement.length.should_be(NORMAL_LENGTH);
            };
        }
    }
}
