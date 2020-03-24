Feature: GenerateErx
	

@regression
Scenario:01. Creating an eRx via Patient Screening
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses 'Screenings' subtab
	When user views completed screening 
	And user generates an eRx
	Then new eRx is created from patient's screening

