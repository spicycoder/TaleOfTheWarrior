Feature: Warrior elf character design
	Character design of the warrior elf
	Who eats, fights and has big ears

Scenario: Initial health is 30
	Given A new player
	Then Health should be 30

Scenario Outline: Feed Food
	Given A new player
	When Eat a <food>
	Then Health should be <health>
	Examples: 
	| food    | health |
	| Carrot  | 40     |
	| Bread   | 50     |
	| Portion | 60     |

Scenario Outline: Feed multiple food
	Given A new player
	When Eat a <food1>
	And Eat a <food2>
	Then Health should be <health>
	Examples: 
	| food1  | food2   | health |
	| Carrot | Bread   | 60     |
	| Carrot | Portion | 70     |
	| Bread  | Portion | 80     |
	| Wine   | Wine    | 100    |

Scenario Outline: When attacked
	Given A new player
	When Attacked <count> times
	Then Health should be <health>
	Examples: 
	| count | health |
	| 1     | 20     |
	| 2     | 10     |
	| 3     | 0      |
	| 5     | 0      |