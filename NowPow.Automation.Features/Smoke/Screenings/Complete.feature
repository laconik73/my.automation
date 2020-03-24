Feature: Complete
	

@smoke
Scenario: 01. Making Patient Screening
	Given 'CPT11' user is logged in
	And user chooses a tab 'Screenings'
	When user chooses  'Start'
	And user answers screening questions
	And saves screening with a note
	Then note is displayed below screening summary
