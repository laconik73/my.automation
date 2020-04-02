Feature: AdditionalField
	
Background: 
Given 'CPT8' user is logged in
And user nagivates to 'Admin' page
And user is on 'Referral Form'

@regression
Scenario: 01.Verify Additional Fields Section
	When user adds new field	
	Then new additional field becomes required 
	And 'Yes' is displayed in the section
