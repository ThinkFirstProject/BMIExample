Feature: Register anamnesis data	
	As a user
    I can register anamnesis data of a person
    In order to calculate the persons bmi

Scenario: A measurement with new anamnesis data can be added
    Given an existing person
    And I want to register new anamnesis data for this person
    When I provide as length 180 
    And I provide as weight 75000
	And I provide as date 12-12-2012
    And I choose to register
    Then a new measurement is added to the anamnesis history of this person with the data provided

Scenario Outline: An error message is given if not all mandatory fields are provided 
    Given an existing person
    And I want to register new anamnesis data for this person
    When I leave a "<mandatoryField>" empty
	And all other data is valid
    And I choose to register
    Then the error message "<errorMessage>" is given  
    Examples: 
    | mandatoryField | errorMessage         |
    | Length         | Length is mandatory |
    | Weight         | Weight is mandatory |

Scenario Outline: An error message is given if invalid data is provided
    Given an existing person
    And I want to register new anamnesis data for this person
    When I enter an "<invalidValue>" in a "<field>"
	And all other data is valid
    And I choose to register
    Then the error message "<errorMessage>" is given
    Examples: 
    | field  | invalidValue       | errorMessage                             |
    | Length | one hundred eighty | Not a numeric length                     |
    | Length | 49                 | Length should be between 50 and 300      |
    | Weight | 1999               | Weight should be between 2000 and 700000 |
    | Weight | seven thousand     | Not a numeric weight                     |
    | Date   | 10-10-2016         | Date should not be in the future         |
	
Scenario: An error message is given if a measurement is already registered for the current date and time
    Given an existing person
    And the person has a measurement on 9-9-2009
    And I want to register new anamnesis data for this person 
    When I provide as date 9-9-2009
    And all other data is valid
    And I choose to register
    Then the error message "A measurement for this moment is already registered" is given

