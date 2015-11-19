Feature: Measurement

Scenario Outline: A new measurement object can be created
	Given a length <Length> is provided
	And a weight  <Weight> is provided
	And a valid date is enterd
	When i try to create a new measurement object with <Circumstance>	
	Then the measurement object is created with the enterd data
	Examples: 
	| Circumstance             | Length | Weight |
	| normal length            | 180    | 75000  |
	| just big enough length   | 25     | 75000  |
	| just small enough length | 275    | 75000  |
	| normal weight            | 180    | 75000  |
	| just big enough weight   | 180    | 300    |
	| just small enough weight | 180    | 600000 |

Scenario Outline: When creating a measurement object, the length has to be valid	
	Given an invalid length <Value> is provided, which is invalid because <Input_problem>
	And all other parameters are valid
	When i try to create a new measurement
	Then the measurement object should throw an argument exception
	Examples: 
	| Input_problem       | Value |
	| lot to small length | 15    |
	| bit to small length | 24    |
	| bit to big length   | 276   |
	| lot to big length   | 300   |

Scenario Outline: When creating a measurement object, the weight has to be valid	
	Given an invalid weight <Value> is provided, which is invalid because <Input_problem>
	And all other parameters are valid
	When i try to create a new measurement
	Then the measurement object should throw an argument exception
	Examples: 
	| Input_problem       | Value  |
	| lot to small weight | 100    |
	| bit to small weight | 299    |
	| bit to big weight   | 600001 |
	| lot to big weight   | 660000 |

Scenario Outline: A measurements length can be modified
	Given a valid measurement object
	When i try to change the length to <Value>, which is <Circumstance>
	Then the measurement object should be updated with the new length value
	Scenarios: 
	| Circumstance             | Value |
	| OTHER_normal length      | 190   |
	| just big enough length   | 25    |
	| just small enough length | 275   |

Scenario Outline: A measurements weight can be modified
	Given a valid measurement object
	When i try to change the weight to <Value>, which is <Circumstance>
	Then the measurement object should be updated with the new weight value
	Scenarios: 
	| Circumstance             | Value  |
	| OTHER_normal weight      | 80000  |
	| just big enough weight   | 300    |
	| just small enough weight | 600000 |
	
Scenario Outline: When modifying the length of a measurement, the length should be valid
	Given a valid measurement object
	When i try to change the length to <Value>, which is <Circumstance>	
	Then the measurement object should throw an argument exception
	Scenarios: 
	| Circumstance        | Value |
	| lot to small length | 15    |
	| bit to small length | 24    |
	| bit to big length   | 276   |
	| lot to big length   | 300   |

Scenario Outline: When modifying the weight of a measurement, the weight should be valid
	Given a valid measurement object
	When i try to change the weight to <Value>, which is <Circumstance>	
	Then the measurement object should throw an argument exception
	Scenarios: 
	| Input_problem       | Value  |
	| lot to small weight | 100    |
	| bit to small weight | 299    |
	| bit to big weight   | 600001 |
	| lot to big weight   | 660000 |

Scenario: A measurement can be modified with a new date
	Given a valid measurement object
	When the date is changed with a valid value: 5-10-2013
	Then the measurement object should be updated with the new date

Scenario: A measurement can be compared to a measurement which is null
	Given a valid measurement object
	And another measurement object is created which is null
	When the measurement object is compared to the other measurement
	Then the result should be positive

Scenario Outline: A measurement can be compared to another measurement
	Given a valid measurement object with date 1-1-2001
	And another measurement object is created with the date <Value> which is <Circumstance>
	When the measurement object is compared to the other measurement
	Then the result should be <Result>
	Examples: 
	| Circumstance    | Value    | Result   |
	| an earlier date | 1-1-2000 | positive |
	| a later date    | 1-2-2001 | negative |
	| the same date   | 1-1-2001 | zero     |

Scenario: A measurement can be checked for equality to a measurement which is null
	Given a valid measurement object
	And another measurement object is created which is null
	When i try to check for equality between both measurements
	Then the result should be false

Scenario Outline: A measurement can be checked for equality to another measurement
	Given a valid measurement object with date 1-1-2001
	And another measurement object is created with the date <Value> which is <Circumstance>
	When i try to check for equality between both measurements
	Then the result should be <Result>
	Examples: 
	| Circumstance    | Value    | Result |
	| an earlier date | 1-1-2000 | false  |
	| a later date    | 1-2-2001 | false  |
	| the same date   | 1-1-2001 | true   |