Feature: ExpectedWalkIn
	

@uat
@regression
Scenario: 01.Setting Expected Walk-In Appointment to "No Show" via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user opens Edit Referral modal with appointment
	And user saves expected walk-in with the status 'No Show'
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
