@cpt_username

Feature: Needs

Scenario: 01.Adding a patient Need with a note
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user opens subtab 'Needs'
	When a user adds a new Needs with a note
	Then new note is added


Scenario:02. Adding a patient Need Interaction
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user opens subtab 'Needs'
	When user adds a new interaction to an existing Needs
	And user expands Need card's details
	Then new interaction is added

	



	 




