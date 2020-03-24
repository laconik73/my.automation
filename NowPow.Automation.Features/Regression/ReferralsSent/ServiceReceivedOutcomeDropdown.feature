Feature: ServiceReceivedOutcomeDropdown
	

@regression
Scenario: 01.Verify Service Received/Outcome dropdown appearance
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user clicks on status 'New'
	And user edits acceptance status to 'Accepted'
	Then 'Contact Status' container displays
	And 'service received' and 'service outcome' are not displayed
	And user selects 'Contacted' status
	Then 'service received' and 'service outcome' are displayed
	And user chooses contact status 'Other'
	Then 'service received' and 'service outcome' are displayed
	And user sets contact status to 'Unable to Contact'
	Then service received autofills to 'No'
	Then service outcome autofills to 'Unsuccessful'
	And user selects contact status 'Attempt to Contact'
	And 'service received' and 'service outcome' are not displayed
