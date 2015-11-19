Feature: Calculate BMI 
   As a user
   I can ask the bmi of a person
   In order to assess the person’s medical condition

   #Waarom zo'n beschrijving?
Scenario Outline: The bmi is calculated based on the length and the weight of a person
    Given an existing person
    And a last measurement with length <length> and weight <weight>
    When I choose to calculate the bmi of this person
    Then the bmi is <bmi>
    Examples:
	| length | weight | bmi   |
	| 160    | 65000  | 25.39 |
	| 180    | 75000  | 23.15 |
						
Scenario: The bmi is calculated based on the most recent anamnesis of the person
	Given an existing person
	And a measurement on 12-12-2012 with length 180 and weight 65000
	And a measurement on 12-12-2013 with length 180 and weight 75000
	When I choose to calculate the bmi of this person
	Then the bmi is 23.15

Scenario Outline: The bmi is rounded to 2 digits
	Given an existing person
	And a last measurement with length <length> and weight <weight>
	When I choose to calculate the bmi of this person
	Then the bmi is <bmi>
	Examples:  
	| length | weight | bmi   |
	| 160    | 65000  | 25.39 |
	| 160    | 65001  | 25.39 |
	| 160    | 65009  | 25.39 |
	| 180    | 75000  | 23.15 |
	| 180    | 75009  | 23.15 |

#scenario kan niet vanwege de constructor van person dus ???
#Scenario: An error message is given if there is no data to calculate the bmi
	#Given an existing person
	#And no measurements
	#When I choose to calculate the bmi of this person
	#Then the error message “There is no anamnesis data available of this person to calculate the bmi of this person” is given