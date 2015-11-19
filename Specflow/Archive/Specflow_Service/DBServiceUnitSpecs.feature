Feature: Serivce unit tests for the database service

Scenario: A list of people can be saved to the database
	Given a database service(unit)
	And a list of new people is provided(unit)
	When i try to save the list of people to the database(unit)
	Then the list is saved wit no errors(unit)

Scenario: Only the changed people are saved
	Given a database service(unit)
	And a list of people is already saved(unit)
	When i try to save the unchanged list of people to the database(unit)
	Then no updates are performed(unit)

Scenario: When saving a list op people, the list can't be null
	Given a database service(unit)
	And a list of people is provided which is null(unit)
	When i try to save the list of people to the database(unit)
	Then an invalid argument exception is thrown(unit)

Scenario: A list of people can be fetched from the database
	Given a database service(unit)
	And the database is loaded with one person
	When i try to retrieve the list of people
	Then a list of people is returned, containing 1 person