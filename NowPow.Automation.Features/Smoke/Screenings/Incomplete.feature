Feature: Incomplete
	

@smoke
Scenario: 03. Saving an Incomplete Screening via Patient
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user clicks on 'Conduct Screening' button
	And user chooses  'Start'
	And user saves screening for later
	Then user returns to the Patient's Page with incomplete screening
