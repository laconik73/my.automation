Feature: AdditionalField
	

@regression
Scenario: 01.Verify Additional Fields Section
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	When user is on 'Referral Form'
	Then 'Additional Fields' section is displayed below 'NowPow Default Fields'
	And user selects 'Add New Field'
	And user adds required field for services
	Then new additional field beocmes required and displayed 'Yes' in the section
