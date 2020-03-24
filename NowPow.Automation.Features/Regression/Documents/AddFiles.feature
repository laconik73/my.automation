Feature: AddFiles
	

@regression
Scenario: 01. Add files to Sent Referrals
	Given 'CPT' user is logged in
	And user is on 'Referrals Sent' page
	When user is on referral with attached document
	Then file is added to Sent Referrals

Scenario: 02. Add files to Received Referrals
	Given 'CPT3' user is logged in
	When user is on received referrals with attached document
	Then file is added to Received Referrals

Scenario: 03. Verify "Add Document" button
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds document
	And user adds another document
	Then the files display as separate lines
