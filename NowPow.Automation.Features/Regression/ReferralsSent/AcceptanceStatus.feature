Feature: AcceptanceStatus
	

@regression
Scenario: 01. Verify Referal Sender able to change acceptance status
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'		
	And user chooses patient card	
	And user chooses subtab 'Referrals'	
	When user clicks on status 'New'
	And user changes acceptance status to 'Waitlisted'
	Then acceptance status is changed
