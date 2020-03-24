Feature: AddRemove
	

@regression
Scenario: 01. Add/Remove files from Sent Referrals
	Given 'CPT' user is logged in
	And user is on 'Referrals Sent' page
	When user is on referral with attached document
	And user decides to delete a document
	Then document is removed from Sent Referrals

Scenario: 02. Add/Remove files from Received Referrals
	Given 'CPT3' user is logged in
	When user is on received referrals with attached document
	And user deletes document
	Then document is removed from Received Referrals

Scenario:03. Remove files from Referral modal
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds document
	And user adds another document
	And user deletes a document
	Then document is removed

