Feature: BuildNewErx
	

@smoke
Scenario:01. Verify Building New eRx button via Patient Card
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user selects button 'Build New eRx'  
	Then 'eRx Landing' displays 'centered pannel'
	And user chooses 'Back to Patient' button
	Then user is back on 'Overview' patient card

Scenario:02. Build New eRx via Patient Card
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user selects button 'Build New eRx'
	When user inputs address into the 'Location'
	And user selects 'Conditions'
	And user makes selections from 'Add Filters'
	Then 'HealtheRx' is generated
