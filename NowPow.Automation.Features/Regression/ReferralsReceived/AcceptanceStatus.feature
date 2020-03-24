Feature: AcceptanceStatus
	

@regression
Scenario: 01.Set Referral Acceptance to "Accepted" via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user saves acceptance status as 'Accepted'
	Then 'Last Update' display acceptance status
	And user reopens 'Edit Referral' modal
	Then acceptance status change interaction is displayed


Scenario: 02. Setting Referal Acceptance to Waitlisted via Referral Received 
	Given 'CPT2' user is logged in
	And user chooses Referrals Received	
	When user clicks on status 'New'
	And user changes acceptance status to 'Waitlisted'
	Then acceptance status is changed
