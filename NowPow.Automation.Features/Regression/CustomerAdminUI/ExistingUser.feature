Feature: ExistingUser
	

@regression
Scenario: 01. Check for existing user
	Given 'CPT7' user is logged in
	And user is on 'Customer Admin UI'
	When user on 'Add User' modal
	And user checks the checkbox 'Use a different email for username'
	And  user inputs duplicate username in the same org
	Then 'Edit existing user' blue link is displayed
	And user inputs duplicate username in the different org and same network
	Then 'Edit existing user' blue link is NOT displayed
