Feature: MeasurementFeature
	To maintain a history of person data, the data should be stored in measurement objects.

Scenario Outline: Measurement is created with valid length and constant valid weight and date
	When A valid weight is enterd: 75000 g
	And A valid date is enterd: "5-10-2013" 
	And A valid length is enterd: [Valid_input] -> [Value]
	And The measurement object is generated	
	Then The measurement object should contain the enterd data
	Examples: 
	| Valid_input              | Value |
	| NORMAL_LENGTH            | 180   |
	| JUST_BIG_ENOUGH_LENGTH   | 25    |
	| JUST_SMALL_ENOUGH_LENGTH | 275   |

Scenario Outline: Measurement is created with valid weight and date. But with an invalid length	
	When A valid date is enterd: "5-10-2013"
	And A valid weight is enterd: 75000 g
	And An invalid length is enterd: [Input_problem] -> [Value]	
	And The measurement object is generated	
	Then The measurement object should throw an invalid length error
	Examples: 
	| Input_problem       | Value |
	| LOT_TO_SMALL_LENGTH | 15    |
	| BIT_TO_SMALL_LENGTH | 24    |
	| BIT_TO_BIG_LENGTH   | 276   |
	| LOT_TO_BIG_LENGTH   | 300   |

Scenario: Measurement is modified with a valid date	
	Given A valid measurement object is generated: 75000 g , 180 cm , "5-10-2013"
	When The date is changed with a valid value: 6 - 10 - 2013
	Then The measurement object should be updated with the new date

Scenario: Measurement is modified with a valid length
	Given A valid measurement object is generated: 75000 g , 180 cm , "5-10-2013"
	When The length is changed: BIT_TO_SMALL_LENGTH -> 24
	Then The measurement object should throw an error and the length should not be changed

Scenario: Measurement is modified with a invalid length
	Given A valid measurement object is generated: 75000 g , 180 cm , "5-10-2013"
	When The length is changed: JUST_BIG_ENOUGH_LENGTH -> 25
	Then The measurement object should be updated with the new length