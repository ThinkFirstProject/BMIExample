Feature: Maintaining the personal data of a user
	As a user 
	I want to manage the personal data of a user
	So i can manage the user who's BMI are tracked

Scenario: A new user can be created
	Given valid personal data is provided
	And a valid starting measurement is provided
	When i try to generate a new user
	Then the new user is generated

Scenario Outline: When creating a new user, the data has to be valid
	Given personal data is provided which is invalid	
	| Social security number   | Gender   | Birthdate   |
	| <Social security number> | <Gender> | <Birthdate> |
	And a valid starting measurement is provided
	When i try to generate a new user
	Then an error is returned containing the message <Error>
	Examples: 
	| Error                          | Social security number | Gender | Birthdate  |
	| Invalid social security number | null                   | Male   | 01-01-2001 |

Scenario: When creating a new user, the first measurement has to be valid
	Given valid personal data is provided	
	And an invalid first measurement is provided
	When i try to generate a new user
	Then an error is returned containing the message Invalid first measurement

Scenario: The personal info of a user can be changed
	Given a valid user
	And new valid personal data is provided
	When i try to change the personal data of the user
	Then the personal data of the user is changed

Scenario Outline: When changing the personal data of a user, the enterd data has to be valid
	Given a valid user
	And new invalid personal data is provided
	| Social security number   | Gender   | Birthdate   |
	| <Social security number> | <Gender> | <Birthdate> |
	When i try to change the personal data of the user
	Then an error is returned containing the message <Error>
	Examples: 
	| Error                          | Social security number | Gender | Birthdate  |
	| Invalid social security number | null                   | Male   | 01-01-2001 |

