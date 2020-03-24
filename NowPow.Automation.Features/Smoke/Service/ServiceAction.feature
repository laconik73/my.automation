Feature: ServiceAction
	

@smoke
Scenario:01. Verify  "Service" action display via Patient Needs
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'	
	And user chooses patient card
	And user opens subtab 'Needs'
	When user expands 'Take Action'
	Then 'Service' action is displayed
