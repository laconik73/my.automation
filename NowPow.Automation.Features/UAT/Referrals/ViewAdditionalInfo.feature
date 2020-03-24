Feature: ViewAdditionalInfo
	

@uat
@regression
Scenario:01. Verify "View Additional Info" button via Referral Receiver
	Given 'CPT4' user is logged in
	And user chooses Referrals Received
	When user opens 'View Additional Info'
	Then modal display 'Patient Info' and 'Custom Additional Fields'
	And closing modal keeps chevron down open with patient info displayed
	And user navigates through each bucket in 'Task View'
	Then 'View Additional Info' displayed below Client Info section