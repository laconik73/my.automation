Feature: AutomaticErx
	

@regression
Scenario:01. Generating Automatic eRx via Patient Card
	Given 'CPT12' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient Name 'sabina'
	When user navigates to 'Generate Automatic eRx'  
	Then user is able to 'Add New' or 'Save' eRx
	And user chooses 'Back to Patient' button
	Then user is back on 'Overview' patient card
