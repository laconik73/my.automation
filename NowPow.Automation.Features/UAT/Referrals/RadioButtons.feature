Feature: RadioButtons
	

@uat
@regression
Scenario: 01. Verify radio buttons via Referrals Sent
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user selects 'View By' clients radio button
	Then referrals list is grouped by 'Client Name'
	And user selects 'View By' services radio button
	Then referrals list is grouped by 'Service type'

Scenario: 02.Verify radio buttons via Referrals Received
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	When user selects 'View By' clients radio button
	Then referrals list is grouped by 'Client Name'
	And user selects 'View By' services radio button
	Then referrals list is grouped by 'Service type'

