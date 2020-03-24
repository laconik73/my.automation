Feature: ServiceOutcome
	

@regression
Scenario: 01.Set Service Outcome to 'Successful' via Referrals Sent
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user saves a service outcome as 'Successful' with a note
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction


Scenario: 02.Set Service Outcome to 'Neutral' via Referrals Sent
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user saves service outcome as 'Neutral' with a note
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

