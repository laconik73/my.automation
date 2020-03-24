Feature: SearchPatient
	

@smoke
Scenario:01. Verifying New Patient Card
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	When user inputs new patient name into 'Search' field
	Then results displayed
