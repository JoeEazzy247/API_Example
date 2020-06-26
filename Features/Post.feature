Feature: Post
	In order to have access to regres site
	I need to create a new user
	

@mytag
Scenario: Create a new user
	Given I have access to regres.in site
	When I enter new user details
	Then I should see status "201" 
