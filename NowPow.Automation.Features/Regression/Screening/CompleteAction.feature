Feature: CompleteAction
	

@regression
Scenario: 01. Verify Screening Auto Save functionality
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user expands 'Take Action'
	Then 'Complete' screening action is displayed
	