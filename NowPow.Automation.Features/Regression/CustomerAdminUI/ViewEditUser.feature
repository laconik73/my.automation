Feature: ViewEditUser
	

@regression
Scenario:01. View/Edit  user via 'Take Action' button
	Given 'CPT5' user is logged in
	When chooses to edit single user
	Then user is updated instead of added

Scenario: 02. Edit existing user via 'Add Users' button
	Given 'CPT5' user is logged in
	When user on 'Add User' modal
	And user checks the checkbox 'Use a different email for username'
	And user edits information of the existing user
	Then existing user information is updated
