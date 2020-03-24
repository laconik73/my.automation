Feature: NowPowDefaultField
	

@smoke
Scenario: 01. Verify NowPow Default Fields Section display
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	When user is on 'Referral Form'
	Then 'NowPow Default Fields' section is displayed
	And user selects the checkbox
	Then selected checkbox indicates that particular field is required on the Referral Form
