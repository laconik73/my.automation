Feature: AddUsersButton
	

@smoke
Scenario: 06.Verify Network and Enterprise levels not able to add users
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user on 'Customer Admin UI'
	When 'Network Admin' views administration hierarchy
	And user chooses Network level
	Then 'Add Users' button is not visible on the page
	And users cannot be added at 'Network' level
	When 'Network Admin' views administration hierarchy
	And user chooses Enterprise level
	Then 'Add Users' button is not visible on the page
	And users cannot be added at 'Enterprise' level
