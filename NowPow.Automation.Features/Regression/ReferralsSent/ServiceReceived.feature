Feature: ServiceReceived
	

@regression
Scenario:01.Set Service Received to 'Yes' via Patient Referrals 
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user saves service received as 'Yes'
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
