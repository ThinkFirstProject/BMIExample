Feature: Person

Scenario: a person can be created
	Given valid personal data is provided
	| Social security number | Birthdate | Gender |
	| 10                     | 1-1-2001  | Male   |
	And a valid measurement is provided
	| Length | Weight | Date     |
	| 180    | 68000  | 2-1-2001 |
	When i try to create a person object
	Then the object is created and contains the provided data

Scenario Outline: When creating a person, the social security number should be valid
	Given a social security number <Value> is enterd which is invalid because <Reason>
	And all other parameters are valid
	When i try to create a person object
	Then the object should throw an invalid argument exception
	Examples:
	| Value | Reason      |
	| null  | null value  |
	| empty | empty value |

Scenario: When creating a person, the measurement can't be null
	Given a measurement which is null 
	And all other parameters are valid
	When i try to create a person object
	Then the object should throw an invalid argument exception

Scenario: the social security number can be changed
	Given a valid person object is generated 
	When  i try to change the social security number to the value 20
	Then the person object should contain the provided social security number

Scenario Outline: When changing the social security number, the provided social security number should be valid
	Given a valid person object is generated 
	When i try to change the social security number to <Value> which is invalid because <Reason>	 
	Then the object should throw an invalid argument exception
	Examples:
	| Value | Reason      |
	| null  | null value  |
	| empty | empty value |


Scenario: the birthdate can be changed
	Given a valid person object is generated 
	When i try to change the birthdate to 02-01-2005
	Then the object should be updated with the new birthdate

Scenario: the gender can be modified
	Given a valid person object is generated 
	When i try to change the gender to Female
	Then the object should be updated with the new gender

Scenario: a new valid measurement can be added
	Given a valid person object is generated  
	And a new valid measurement is provided
	When i try to add the new measurement
	Then the object should contain the new measurement

Scenario: When adding a new measurement, the provide measurement can't be null
	Given a valid person object is generated 
	And a measurement which is null
	When i try to add the new measurement
	Then the object should throw an invalid argument exception

Scenario: The last measurement can be removed
	Given a valid person object is generated  
	And a new valid measurement is added 
	When i try to remove the last measurement
	Then the measurement should be removed from the object

Scenario: The last measurement can be fetched
	Given a valid person object is generated  
	And a new valid measurement is added 
	When i try to fetch the last measurement
	Then the last measurement is returned
	
Scenario Outline: A person object can be checked for equality to another person object
	Given a valid person object is generated with social security number 10  
	And another valid person object is generated with social security number <Value>, which is <Circumstance>
	When the objects are compared for equality
	Then the returned result should be <Result>
	Examples:
	| Value | Circumstance   | Result |
	| 1     | a lower value  | false  |
	| 10    | the same value | true   |
	| 20    | a higher value | false  |

Scenario: the BMI is calculated of the most recent measurement
	Given a valid person object is generated
	And a new valid measurement is added 
	When i try to calculate the BMI of the person	
	Then the BMI result is returned for the last enterd measurement