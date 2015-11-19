Feature: Maintain measurement data of a user
	As a user
	I want to maintain my history of BMI measurements
	So i can track my BMI progress

Scenario: A new measurement can be added
	Given a valid user
	And I provide valid measurement data
	When I try to add the new measurement
	Then the new measurement is added to my BMI history

Scenario Outline: When adding a new measurement, the data has to be valid
	Given a valid user
	And I provide data which is invalid	
	| Length       | Weight      | Date   |
	| <Length(cm)> | <Weight(g)> | <Date> |
	When I try to add the new measurement
	Then an error is returned containing the message <Error>
	Examples: 
	| Error          | Length(cm) | Weight(g) | Date       |
	| Invalid length | 10         | 75000     | 01-01-2001 |
	| Invalid weight | 180        | 5         | 01-01-2001 |

Scenario: The most recent measurement can be retrieved
	Given a valid user which has a valid measurement
	When i try to fetch the most recent measurement
	Then the requested measurement is returned

Scenario: The most recent measurement can be removed
	Given a valid user which has a valid measurement
	When i try to remove the most recent measurement
	Then the measurement is removed