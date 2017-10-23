Feature: Create New Quick Request
	Check if the quick request functionality is working
	as expected

Scenario: Submit New Quick Request
	When Logged in
	Given See NewQuickRequest button on the entrance page
	Then Click the NewQuickRequest button
	Given The Page is loaded
	Then Add location
	And Write Problem/Necessity, Observations and Contact
	| ProblemNecessity | Observation     | Contact    |
	| wer              | Automation Test | 2298183741 |
	Then Click confirm button
	Then Go to Home Page