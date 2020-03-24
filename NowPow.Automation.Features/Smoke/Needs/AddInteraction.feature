Feature: AddInteraction
	

@smoke
Scenario:01. Adding a patient Need Interaction
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'	
	And user chooses patient card
	And user opens subtab 'Needs'
	When user adds a new interaction to an existing Needs
	And user expands Need card's details
	Then new interaction is added
