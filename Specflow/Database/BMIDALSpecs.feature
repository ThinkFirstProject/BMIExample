Feature: Saving and loading data from the BMI data access layer
	As a user
	I want to save and load all personal and anamnesis data for a person
	So i can monitor the BMI evolution

Scenario: A new person with anamnesis data can be saved to the database
	Given the BMIDAL
	When a valid person object with anamnesis data is provided
	And i try to save the person object to the database
	Then the data of the person object is stored in the database

Scenario: When adding a new person to the database, duplicate entries are ignored
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When a valid person object with anamnesis data is provided with social security number 123456789
	And i try to save the person object to the database
	Then no changes are made to the database, the entry is ignored

Scenario: When adding a new person to the database, the person object can't be null
	Given the BMIDAL
	When a person object is provided,which is null
	And i try to save the person object to the database
	Then an exception is thrown

Scenario: A person with anamnesis data can be retrieved
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When an existing social security number is provided
	And i try to fetch the data for the person from the database
	Then the requested person object with his anamnesis data is returned

Scenario: When fetching a person with anamnesis data, the person has to exist
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When a non-existing social security number is provided
	And i try to fetch the data for the person from the database
	Then null is returned

Scenario: When fetching a person with anamnesis data, the social security number can't be null
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When a social security number is provided, which is null
	And i try to fetch the data for the person from the database
	Then an exception is thrown

Scenario: New anamnesis data can be stored for a person
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When a valid measurement object is provided
	And an existing social security number is provided
	And i try to add the new anamnesis data to the database
	Then the new anamnesis data is added to the database

Scenario: When adding new anamnesis data for a person, the measurement object can't be null
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When a measurement object is provided which is null
	And an existing social security number is provided
	And i try to add the new anamnesis data to the database
	Then an exception is thrown

Scenario: When adding new anamnesis data for a person, the social security number has to exist
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When a valid measurement object is provided
	And a social security number 5 is provided, which is invalid because: value doesn't exist
	And i try to add the new anamnesis data to the database
	Then null is returned

Scenario Outline: When adding new anamnesis data for a person, the social security number has to be valid
	Given the BMIDAL
	And the database contains a person with 123456789 as social security number
	When a valid measurement object is provided
	And a social security number <socialSecurityNumber> is provided, which is invalid because: <reason>
	And i try to add the new anamnesis data to the database
	Then an exception is thrown
	Examples:
	| socialSecurityNumber | reason              |
	| null                 | value is null       |
	|                      | value is blank      |
	
Scenario: A list of all registerd social security numbers can be fetched
	Given the BMIDAL
	And the database contains 1 person with social security number 123456789
	When i try to fetch a list of all stored social security numbers
	Then a list with one entry = 123456789 is returned
