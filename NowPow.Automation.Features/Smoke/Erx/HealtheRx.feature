Feature: HealtheRx
	

@smoke
Scenario:01. Viewing eRx from eRx Page
	Given 'CPT9' user is logged in
	And user chooses 'eRx' tab
	And 'eRx Landing' displays 'centered pannel'
	When user chooses to 'View Existing HealtheRx'
	And user inputs 'HealtheRx' code
	Then displayed eRx code matches the inputted 'HealtheRx' code
