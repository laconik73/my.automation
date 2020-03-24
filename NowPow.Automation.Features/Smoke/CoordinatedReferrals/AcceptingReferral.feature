Feature: AcceptingReferral
	

@smoke
Scenario: 01. Verify error message display for Referral Sender
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'	
	When user clicks on status 'New'
	And user accepts referal sent
	Then 'error' message is displayed