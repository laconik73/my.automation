Feature: ContactStatus
	

@regression
Scenario:01. Verify Contact Status Display
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user opens Edit Referral modal
	And user edits acceptance status to 'Accepted'	
	Then 'Contact Status' container displays
	And user changes acceptance status to 'Waitlist'
	Then 'Contact Status' container is not visible
	And user selests acceptance status as 'Denied'
	Then action button displays 'Close Referral'

Scenario: 02.Set Contact Status to 'Contacted' via Patient Referrals 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user saves a contact status as 'Contacted' 
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

Scenario:03. Set Contact Status to 'Attempted to Contact' via Patient Referrals 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user saves contact status as 'Attempted to Contact' 
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
	

Scenario:04.Set Contact Status to 'Unable to Contact' via Patient Referrals 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user saves contact status to 'Unable to Contact' 
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

Scenario:05. Set Contact Status to 'Other' via Patient Referrals 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user saves a contact status to 'Other' 
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
