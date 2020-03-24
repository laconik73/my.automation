Feature: Details
	

@uat
@regression
Scenario: 01. Hide eRx interaction from screeing view (coordinated taker)
	Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user searches for a patient that completed a screening
	And user chooses 'Screenings' subtab
	When user views screening details
	Then interaction of eRx creation is hidden and not displayed
