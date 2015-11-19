Feature: Specifications for the controller

Scenario: The viewresult with an overview of all people can be fetched
	Given a BMIController
	When i try to fetch the viewresult for the overview of registerd people
	Then the viewresult for the for the overview of registerd people is returned

Scenario: The viewresult for adding a measurement can be fetched
	Given a BMIController	
	And a valid datamodel is provided
	When i try to fetch the viewresult for adding a measurement
	Then the viewresult for adding a measurement is returned

Scenario: When fetching the viewresult for adding a new measurement, the provided datamodel can't be null
	Given a BMIController
	And a datamodel which is null is provided
	When i try to fetch the viewresult for adding a measurement
	Then an exception is thrown

Scenario: The viewresult for adding a new person can be fetched
	Given a BMIController
	When i try to fetch the viewresult for adding a person
	Then the viewresult for adding a person is returned

Scenario Outline: When trying to fetch the viewresult for the details of a person, the social security number has to exist. And has to be valid
	Given a BMIController
	And the provide social security number is <SocialSecurityNumber>, which is <Error>
	When i try to fetch the viewresult for viewing the details of a person
	Then an exception is thrown
	Examples: 
	| SocialSecurityNumber | Error        |
	| 5                    | non existent |
	|                      | empty        |
	| null                 | null value   |

Scenario: A new person can be added
	Given a BMIController
	And a datamodel with valid data for a person is provided
	When i try to add the new person
	Then the viewresult contains a message indicating the person is added

Scenario: When adding a new person, the provided datamodel has to be valid
	Given a BMIController
	And a datamodel with invalid data for a person is provided
	When i try to add the new person
	Then the viewresult contains an error

Scenario: When adding a new person, the provided datamodel can't be null
	Given a BMIController
	And a datamodel which is null is provided
	When i try to add the new person
	Then the viewresult contains a data error


