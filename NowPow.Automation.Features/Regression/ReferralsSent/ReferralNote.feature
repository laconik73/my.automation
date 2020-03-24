Feature: ReferralNote
	

@regression
Scenario: 01. Adding a Referral Note via Patient Referrals 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user saves referral with a note
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
