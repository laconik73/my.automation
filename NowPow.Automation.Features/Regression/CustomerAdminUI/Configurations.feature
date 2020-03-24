Feature: Configurations
	

@regression
Scenario: 01. Configurations side-panel display
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	When user expands 'Configurations' side panel
	Then 'Referral Form' and 'Service Outcome' subtabs are displayed
	And user chooses 'Referral Form'
	And user expands Organization Level
	Then Admin hierarchy is displayed
	And user chooses 'Service Outcome' side-panel
	Then 'Org Level' displays user organization they are currently logged into
