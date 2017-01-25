Feature: Calc1Demo
	I want to test the sum of two numbers
	Test the addition/subtraction/multiplication/division of two numbers
	also use decimal numbers

Scenario Outline: Test basic operations on two numbers
	Given I have opened calculator
	And I have entered <value1> into the calculator
	And I have entered <operator> into the calculator
	And I have entered <value2> into the calculator
	When I press Equals
	Then the result should be <result> on the screen

	Examples: 
	| value1 | operator | value2 | result |
	| 30     | +        | 60     | 90     |
	| 7,5    | +        | 3      | 10,5   |
	| 4      | -        | 1      | 3      |
	| 35     | *        | 2      | 70     |
	| 4      | /        | 2      | 2      |
	| 5      | -        | 6      | -1     |
	