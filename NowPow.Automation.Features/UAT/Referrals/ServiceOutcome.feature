Feature: ServiceOutcome
	

@uat
@regression
Scenario:01.Set Service Received to 'No' via Patient Referrals 
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user sets service received to 'No'
	Then service outcome default display set to 'Unsuccessful'
	And user saves referral
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

Scenario:02.Set Service Outcome to 'Unsuccessful' via Referrals Sent
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user saves a service outcome to 'Unsuccessful' with a note
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
