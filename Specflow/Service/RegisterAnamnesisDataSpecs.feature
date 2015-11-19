Feature: Register Amnesis Data
			As a user
			I can register anamnesis data of a person
			In order to calculate the person’s bmi

	#!! And I want to register new anamnesis data for this person -> step voert niets uit, dus nodig?
    Scenario: A measurement with new anamnesis data can be added
        Given an existing person
        When I provide as length 180 
        And I provide as weight 75000
        And I provide as date 12-12-2012
        And I try to add the measurement to this person
        Then a new measurement is added to the anamnesis history of this person with the data provided        

	#Scenario: When adding new amnesis data to a person, every field has to be valid
    Scenario Outline: An error message is given when any field of the anamnesis data is invalid
        Given an existing person
        When I provide <invalidValue> as <field>
		And all other data is valid
        And I try to add the measurement to this person
        Then an error message is given
        Examples: 
		| field  | invalidValue |
		| length | 49           |
		| weight | 299          |
		| date   | 10-10-3016	|

	#Scenario: A new measurement with anamnesis data can't be added when a measurement with the same date already exists
    Scenario: An error message is given if a measurement is already registered for the current date and time
	    Given an existing person
        And the person has a measurement on 9-9-2009
        When I provide as date 9-9-2009
        And all other data is valid
        And I try to add the measurement to this person
        Then an error message is given
