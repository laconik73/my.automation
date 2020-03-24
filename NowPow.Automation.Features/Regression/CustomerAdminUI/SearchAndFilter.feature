Feature: SearchAndFilter
	

@regression
Scenario: 01. User search and filtering
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user on 'Customer Admin UI'
	When admin user searches for a user 
	Then search is conducted accross columns
	And user is searching by Organization filter
	Then orgs are displayed based on user's role
	And user searches by user roles
	Then user roles allows multiple selections
	And user selects multiple roles
	Then roles filter will display number of roles selected
	And page retrieves new data and refreshes the list
