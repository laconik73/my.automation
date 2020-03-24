Feature: Nudge
	

@smoke
Scenario:01. Sending Email Nudge via Patient Page
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user sends email nudge with an attachment
	Then new interaction is displayed under patient engagement
