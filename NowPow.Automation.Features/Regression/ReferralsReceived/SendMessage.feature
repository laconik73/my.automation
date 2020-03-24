Feature: SendMessage
	

@regression
Scenario:01. Sending message to Referral Maker via Task View page
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	And user on 'Task View' page
	When user sends a message to a referral maker
	Then message is sent
