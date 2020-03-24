Feature: ViewErx
	

@smoke
Scenario:01.Viewing eRx from Patient Card
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user chooses 'View eRx' button 
	Then referred services are displayed under patient 'eRx' code 
	And user chooses 'Back to Patient' button
	Then user is back on 'Overview' patient card


