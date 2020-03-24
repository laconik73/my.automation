Feature: Download
	

@regression
Scenario: 01. View Shared Documents of Referrals Sent
	Given 'CPT' user is logged in
	And user is on 'Referrals Sent' page
	When user views documents 
	And user downloads document
	Then document is downloaded