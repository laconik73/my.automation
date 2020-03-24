Feature: ClosedInteraction
	

@regression
Scenario: 01. Verify referral closed interaction display via Patient Referrals
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	When user opens referral closed interaction
	Then 'Service outcome details' are formatted properly

Scenario: 02. Verify referral closed interaction display via Notifications
	Given 'CPT12' user is logged in
	And user navigates to 'Notifications'
	When user opens the referral closed interaction
	Then 'Service outcome details' are formatted properly
