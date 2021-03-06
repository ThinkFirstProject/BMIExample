﻿Feature: Specifications for a measurement

Scenario Outline: A new measurement can be created with a length, a weight and a date
    When I want to make a new measurement with length <length>, weight <weight> and date <date>
    Then A new measurement is created
	And the length is <length>
    And the weight is <weight> 
    And the date is <date>
    Examples:        
	| length | weight | date       |
	| 180    | 75000  | 12-12-2012 |
	| 160    | 75000  | 12-12-2012 |
	| 50     | 75000  | 12-12-2012 |
	| 300    | 75000  | 12-12-2012 |
	| 180    | 65000  | 12-12-2012 |
	| 180    | 20000  | 12-12-2012 |
	| 180    | 700000 | 12-12-2012 |
	| 180    | 75000  | 10-10-2012 |
	
Scenario Outline: A new measurement can be created with a length, a weight. Date is autogenerated and set to the current system date
    When I want to make a new measurement with length <length>, weight <weight> and the current date
    Then A new measurement is created 
    And the length is <length>
    And the weight is <weight> 
    And the date is the current date
    Examples:    
	| length | weight |
	| 180    | 75000  |
	| 160    | 75000  |
	| 50     | 75000  |
	| 300    | 75000  |
	| 180    | 65000  |
	| 180    | 20000  |
	| 180    | 700000 |
	
Scenario Outline: A new measurement cannot be created with an invalid length, even if the other data is valid (constructor with 3 parameters)
	When I want to make a new measurement with invalid length <invalidLength>, valid weight <validWeight> and valid date <validDate>
    Then an exception is thrown
    Examples:    
	| invalidLength | validWeight | validDate  |
	| -180          | 75000       | 12-12-2012 |
	| 49            | 75000       | 12-12-2012 |
	| 301           | 75000       | 12-12-2012 |
 
Scenario Outline: A new measurement cannot be created with an invalid length, even if the other data is valid (constructor with 2 parameters)
	When I want to make a new measurement with invalid length <invalidLength>, valid weight <validWeight> and the current date
    Then an exception is thrown
    Examples:    
	| invalidLength | validWeight |
	| -180          | 75000       |
	| 49            | 75000       |
	| 301           | 75000       |
	
Scenario Outline: A new measurement cannot be created with a invalid weight, even if the other data is valid (constructor with 3 parameters)
	When I want to make a new measurement with valid length <validLength>,  invalid weight <invalidWeight> and valid date <validDate>
    Then an exception is thrown     
    Examples:    
	| validLength | invalidWeight | validDate  |
	| 180         | -75000        | 12-12-2012 |
	| 180         | 1999          | 12-12-2012 |
	| 180         | 700001        | 12-12-2012 |
	
Scenario Outline: A new measurement cannot be created with an invalid weight, even if the other data are valid (constructor with 2 parameters)
	When I want to make a new measurement with valid length <validLength>, invalid weight <invalidWeight> and the current date
    Then an exception is thrown
	Examples:    
	| validLength | invalidWeight |
	| 180         | -75000        |
	| 180         | 1999          |
	| 180         | 700001        |
	
Scenario Outline: A new measurement cannot be created with an invalid date, even if the other data is valid
	When I want to make a new measurement with valid length <validLength>,  valid weight <validWeight> and invalid date <invalidDate>
    Then an exception is thrown
    Examples:    
	| validLength | validWeight | invalidDate |
	| 180         | 75000       | 10-10-3016  |
	
Scenario Outline: Measurement can receive a new length
    Given an existing measurement
    When I change the length to <validLength> which is <remark>
    Then the length is <validLength>
    Examples:
    | validLength | remark                |
    | 180         | a normal length       |
    | 160         | another normal length |
    | 50          | the minimum length    |
    | 300         | the maximum length    |

Scenario Outline: Measurement cannot receive an invalid length
    Given an existing measurement
    When I change the length to <invalidLength> which is <remark>
    Then an exception is thrown
    Examples:    
    | invalidLength | remark                  |
    | -180          | a negative length       |
    | 49            | a just too small length |
    | 301           | a just too big length   |

Scenario Outline: Measurement can receive a new weight
    Given an existing measurement
    When I change the weight to <validWeight> which is <remark>
    Then the weight is <validWeight>
    Examples:
    | validWeight | remark                |
    | 75000       | a normal weight       |
    | 65000       | another normal weight |
    | 20000       | the minimum weight    |
    | 700000      | the maximum weight    | 

Scenario Outline: Measurement cannot receive an invalid weight
    Given an existing measurement
    When I change the weight to <invalidWeight> which is <remark>
    Then an exception is thrown  
    Examples:
    | invalidWeight | remark                  |
    | -75000        | a negative  weight      |
    | 1999          | a just too small weight |
    | 700001        | a just too big weight   |

Scenario Outline: Measurement can receive a new date
    Given an existing measurement
    When I change the date to <validDate> which is <remark>
    Then the date is <validDate>
	Examples:
    | validDate  | remark               |
    | 12-12-2012 | a date in past       |
    | 10-10-2012 | another date in past |
  
Scenario Outline: Measurement cannot receive an invalid date
    Given an existing measurement
    When I change the date to <invalidDate> which is <remark>
    Then an exception is thrown
	Examples: 
	| invalidDate | remark           |
	| 10-10-3016  | a date in future |


Scenario Outline: Bmi is calculated, rounded to 2 decimals
    Given an existing measurement
    When the length is <length> and the weight is <weight>
    Then the bmi is <bmi>
    Examples:
	| length | weight | bmi   |
	| 160    | 65000  | 25.39 |
	| 160    | 65001  | 25.39 |
	| 160    | 65009  | 25.39 |
	| 180    | 75000  | 23.15 |


Scenario: Two measurements are equal to each other if the date is equal, even if the lengths or weights differ
    Given an existing measurement with length 180, weight 75000 and date "12-12-2012"
    And another existing measurement with another length 170, another weight 55000 and the same date "12-12-2012"
    When I check if these measurements are equal to each other
    Then true is returned      

Scenario: Two measurements are not equal to each other if the date is different, even if the lengths or weights are equal
    Given an existing measurement with length 180, weight 75000 and date "12-12-2012"
    And another existing measurement with the same length 180, the same weight 75000 and another date "10-10-2012"
    When I check if these measurements are equal to each other
    Then false is returned

Scenario: One measurement is greater than another measurement if the date of the first measurement is more recent
    Given an existing measurement with date "12-12-2012"
    And another existing measurement with date "10-10-2012"
    When I compare the measurement with date "12-12-2012" with the measurement with date "10-10-2012"
    Then a positive number is returned

Scenario: One measurement is smaller than another measurement if the date of the first measurement is older
    Given an existing measurement with date "10-10-2012"
    And another existing measurement with date "12-12-2012"
    When I compare the measurement with date "10-10-2012" with the measurement with date "12-12-2012"
    Then a negative number is returned

Scenario: One measurement is equal than another measurement if the dates of both measurements are the same
    Given an existing measurement with date "10-10-2012"
    And another existing measurement with date "10-10-2012"
    When I compare the measurement with date "10-10-2012" with the measurement with date "10-10-2012"
    Then the number 0 is returned