Feature: DeleteFiles
	

@regression
Scenario: 01. Remove files from Sent Referrals
	Given 'CPT' user is logged in
	And user is on 'Referrals Sent' page
	When user decides to delete a document
	Then document is removed from Sent Referrals

Scenario: 02. Remove files from Received Referrals
	Given 'CPT3' user is logged in
	And user is on Referrals Received page
	When user deletes document
	Then document is removed from Received Referrals

Scenario: 03.Delete document from Patient Document Page
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user chooses 'Delete' action
	And user proceeds with 'Delete'	
	Then document is deleted




