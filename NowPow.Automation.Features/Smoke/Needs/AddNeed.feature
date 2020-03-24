Feature: AddNeed
	

@smoke
Scenario: 01.Adding a patient Need with a note
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'	
	And user chooses patient card
	And user opens subtab 'Needs'
	When a user adds a new Needs with a note
	Then new note is added
