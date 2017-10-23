Feature: Login
	Check if the login functionality is working
	as expected with different permutations and
	combinations of data

Scenario: Login with correct username and password
	Given See the LoginPage opened
	When Write UserName and Password
	| UserName | Password |
	| nb       | teste    |
	Then Click login button
	Then See the username