Feature: SetAppointmentStatus
	

@uat
@regression
Scenario: 01.Set appointment status to "No Show" via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user saves appointment status as 'No Show'
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

Scenario: 02.Set appointment status to "Canceled and Did Not Reschedule" via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user saves appointment status 'Canceled and Did Not Reschedule'
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

Scenario: 03.Set appointment status to "Canceled and Rescheduled" via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user saves appointment status to'Canceled and Rescheduled'
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

