Feature: Appointment
	

@regression
Scenario: 01.Set appointment status to "Attended" via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user sets appointment status as Attended
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

Scenario: 02.Adding a Referral Appointment via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user selects contact status as 'Contacted'
	Then 'Add Appointment' button displays
	And user saves new appointment with a note

Scenario: 03.Deleting a Referral Appointment via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user opens Edit Referral modal with appointment
	And user deletes appointment
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
	

