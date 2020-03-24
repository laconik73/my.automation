Feature: SendMessage
	
@regression
Scenario:01. Sending message to Referral Taker via Patient Referral Page
    Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals' 
	When user sends a message to a referral taker
	Then message is sent
	And user navigates back to patient's referral
	Then all patient referrals are displayed
