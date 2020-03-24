Feature: ViewDocument
	

@regression
Scenario: 01. Verify Referral Sender views same document as Referral Taker
	Given 'CPT' user is logged in
	And user is on 'Referrals Sent' page
	When user views documents
	Then all documents associated to the referral are listed 

Scenario: 02. Verify Referral Taker views same document as Referral Sender
	Given 'CPT3' user is logged in
	And user is on Referrals Received page
	When user views documents on received referrals
	Then all documents associated to the received referrals are listed 
	And user clicks on 'Task View'
	Then same documents are displayed in sidepanel tab related to 'Acceptance Status'
