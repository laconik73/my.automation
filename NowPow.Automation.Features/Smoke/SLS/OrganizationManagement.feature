Feature: OrganizationManagement
	

@smoke
Scenario: 01. Verify Org Management Page search box
	Given 'SLS' user is logged in
	When user searches for an organization
	Then page display matching results 
	And user cleares the input
	Then input box is cleared and page display '1 to 10' organizations
	And user searches for an invalid organization
	Then no search results are displayed
	And user cleares the input
	Then input box is cleared and page display '1 to 10' organizations
