Feature: PatientReferralAccess
	

@regression
Scenario: 01. Verify gained access to all referrals
	Given 'CPT' user is logged in
	When user searches accepted referral
	And user chooses patient card
	And user chooses subtab 'Referrals'
	Then user gaines access to all patient referrals
