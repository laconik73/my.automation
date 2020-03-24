Feature: PatientScreening
	

@smoke
Scenario: 01.Verify Screening via Patient 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user clicks on 'Conduct Screening' button
	Then user able to conduct screening for a patient
