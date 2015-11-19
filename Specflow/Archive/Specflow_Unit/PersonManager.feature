Feature: PersonManager

Scenario: A new person can be added
	Given the singleton instance of personmanager is fetched
	And a valid person is provided
	When i try to add the person
	Then the person is added

Scenario: When adding a new person, the person obj can't be null
	Given the singleton instance of personmanager is fetched
	And a person which is null
	When i try to add the person
	Then the object should throw an invalid argument exception

Scenario: A person can be retrieved
	Given the singleton instance of personmanager is fetched
	And a valid person is added with social security number 10
	When i try to fetch the person with social security number 10
	Then the person object is returned

Scenario Outline: When retrieving a person, the social security number has to be valid
	Given the singleton instance of personmanager is fetched
	And a valid person is added with social security number 10
	When i try to fetch the person with an invalid social security number of <Value>, which is invalid because: <Error>
	Then a null value should be returned
	Examples:
	| Error          | Value |
	| Value is empty |       |
	| Value is null  | null  |
	
Scenario: When retrieving a person, the social security number has to match an existing person
	Given the singleton instance of personmanager is fetched
	And a valid person is added with social security number 10
	When i try to fetch the person with social security number 5
	Then a null value should be returned

Scenario: A list of social security numbers can be fetched
	Given the singleton instance of personmanager is fetched
	And a valid person is added with social security number 10
	When i try to fetch a list of existing social security numbers
	Then a list which contains 1 social security number is returned 

