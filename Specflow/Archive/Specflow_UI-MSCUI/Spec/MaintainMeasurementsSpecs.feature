Feature: Maintain measurement data of a user
	As a user
	I want to maintain my history of BMI measurements
	So i can track my BMI progress

Scenario: A new measurement can be added
	Given a valid user
	And the measurement screen is shown
	And I provide valid measurement data
	When I try to add the new measurement
	Then the new measurement is added to my BMI history

Scenario Outline: When adding a new measurement, the data has to be valid
	Given a valid user
	And the measurement screen is shown
	And I provide data which is invalid	
	| Length       | Weight      | Date   |
	| <Length(cm)> | <Weight(g)> | <Date> |
	When I try to add the new measurement
	Then an error is returned containing the message <Error>
	Examples: 
	| Error                                      | Length(cm) | Weight(g) | Date       |
	| Invalid length                             | 10         | 75000     | 01-01-2001 |	
	| Het veld length is vereist                 |            | 60000     | 01-01-2001 |
	| The value '18a' is not valid for length    | 18a        | 60000     | 01-01-2001 |
	| Invalid weight                             | 180        | 5         | 01-01-2001 |
	| Het veld weight is vereist                 | 180        |           | 01-01-2001 |
	| The value '6000a' is not valid for weight  | 180        | 6000a     | 01-01-2001 |
	| Het veld date is vereist                   | 180        | 60000     |            |
	| The value '15' is not valid for date       | 180        | 60000     | 15         |
	| The value '10--2015' is not valid for date | 180        | 60000     | 10--2015   |