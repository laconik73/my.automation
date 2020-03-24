Feature: EmailToggles
	

@smoke
Scenario:01. Verify Email Consent Toggles
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user switches toggle 'On' and 'Off'
	Then patient confirms email configuration


