Feature: ViewAdditionalInfo
	

@regression
Scenario: 01. Verify "View Additional Info" button via Patient Referral
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user views 'additional info'
	Then modal display Patient Info and 'Custom Additional Fields'
	And closing modal keeps chevron down open with patient info displayed
