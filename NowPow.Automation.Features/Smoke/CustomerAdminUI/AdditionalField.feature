Feature: AdditionalField
	

@smoke
Scenario: 01. Verify Additional Fields Section
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	When user is on 'Referral Form'
	Then 'Additional Fields' section is displayed below 'NowPow Default Fields' 
	And user mouses over to the tooltip
	Then tooltip displays a text
	And user selects 'Add New Field'
	Then modal pops up

Scenario: 02. Verify "Delete" icon in List of Additional Fields
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	When user is on 'Referral Form'
	And user chooses 'Delete' from Additional Fields
	Then additional field is deleted

Scenario: 03.Verify "Edit" icon in List of Additional Fields
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	When user is on 'Referral Form'
	And user chooses 'Edit' icon from Additional Fields
	And user edits fields
	Then fields are edited

Scenario: 04.Verify List of Additional Fields  
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	When user is on 'Referral Form'
	And user navigates to Additional Fields section
	Then list of additional fields are visible
