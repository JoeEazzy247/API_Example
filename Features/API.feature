Feature: API
	I want to see the list of all users on reqres.in


@mytag
Scenario: List user Request Test
	Given I have access to regres.in
	When I request for all users
	Then I should see list of users

Scenario: Single user request Test
	Given I have access to regres.in "https://reqres.in/api/users/2"
	When I request for a users
	Then I should see the user
	And the result should contain "Janet"
	And the result should contain <Name>
	| Name  |
	| Janet |
	
