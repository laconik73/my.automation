Feature: EngagementInteraction
	

@regression
Scenario: 05. Adding a Patient Engagement Interaction
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user adds a new interaction with a note
	Then new interaction is created
	And user chooses 'NowPow' logo
	Then patient card is listed under 'Recent Patients' section
