Feature: Maintaining the personal data of a user
	As a user 
	I want to manage the personal data of a user
	So i can manage the user who's BMI are tracked

Scenario: A new user can be created
	Given the new person page
	And valid personal data is provided
	And a valid starting measurement is provided
	When i try to generate a new user
	Then the new user is generated

Scenario Outline: When creating a new user, the first measurement has to be valid
	Given the new person page
	And valid personal data is provided
	And an invalid first measurement is provided 
	| Length   | Weight   | Date   |
	| <Length> | <Weight> | <Date> |
	When i try to generate a new user
	Then an error is returned containing the message <Error>
	Examples: 
	| Error                                      | Length | Weight | Date       |
	| Het veld length is vereist                 |        | 60000  | 01-01-2001 |
	| The value '18a' is not valid for length    | 18a    | 60000  | 01-01-2001 |
	| Het veld weight is vereist                 | 180    |        | 01-01-2001 |
	| The value '6000a' is not valid for weight  | 180    | 6000a  | 01-01-2001 |
	| Het veld date is vereist                   | 180    | 60000  |            |
	| The value '15' is not valid for date       | 180    | 60000  | 15         |
	| The value '10--2015' is not valid for date | 180    | 60000  | 10--2015   |

Scenario Outline: When creating a new user, the data has to be valid
	Given the new person page
	And personal data is provided which is invalid	 
	| Social security number   | Gender   | Birthdate   |
	| <Social security number> | <Gender> | <Birthdate> |
	And a valid starting measurement is provided
	When i try to generate a new user
	Then an error is returned containing the message <Error>
	Examples: 
	| Error                                           | Social security number | Gender | Birthdate  |
	| Invalid social security number                  |                        | Male   | 01-01-2001 |
	| Invalid social security number                  | null                   | Male   | 01-01-2001 |
	| Het veld birthdate is vereist                   | 10                     | Male   |            |
	| The value '5' is not valid for birthDate        | 10                     | Male   | 5          |
	| The value '10--2015' is not valid for birthDate | 10                     | Male   | 10--2015   |