Feature: ClosingReferral
	

@uat
@regression
Scenario: 01. Setting Referal Acceptance to Denied via Referral Received page
	Given 'CPT2' user is logged in
	And user chooses Referrals Received	
	When user clicks on status 'New'
	And user selests acceptance status as 'Denied'
	Then action button displays 'Close Referral'
	And the referral is closed

Scenario: 02. Closing a referral via Patient Referrals 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user selects status and outcome for an 'Attendance' status
	Then action button displays 'Close Referral'
	And the referral is closed

Scenario: 03. Verify selection of radio buttons require to close the referral
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user selects either radio button	
	And asterisks are present on 'appointment' and 'walk-in' fields	
	Then 'Save' button is displayed 
	And 'attendance' is required to close the referral
	When attendance is filled out
	Then action button displays 'Close Referral'
