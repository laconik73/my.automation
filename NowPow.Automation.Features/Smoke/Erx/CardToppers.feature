Feature: CardToppers
	

@smoke
Scenario:01. Verify card toppers activation
	Given 'CPT9' user is logged in
	And user chooses 'eRx' tab
	And 'eRx Landing' displays 'centered pannel'
	When user inputs address into the 'Location' 
	Then card toppers 'Service Categories' and 'Conditions' are activated

Scenario: 02.Creating an Erx via Service Categories
	Given 'CPT9' user is logged in
	And user chooses 'eRx' tab
	And 'eRx Landing' displays 'centered pannel'
	When user inputs address into the 'Location' 
	And card toppers 'Service Categories' and 'Conditions' are activated
	And user selects 'Service Categories' card topper
	And user makes selections from 'Add Filters'
	Then 'HealtheRx' is generated