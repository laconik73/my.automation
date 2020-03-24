Feature: Nudge
	

@smoke
Scenario: 01.Sending Email Nudge via eRx Page
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user chooses 'View eRx' button
	And user sends nudge
	Then email nudge is sent 