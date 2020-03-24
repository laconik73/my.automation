Feature: GetCode
	
@smoke
Scenario: 04. Verify Screeening with Code via Patient
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user clicks on 'Conduct Screening' button
	And user chooses to complete screening with 'Get Code'
	Then user able to conduct screening for a patent with code
