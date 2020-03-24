Feature: PermissionRole
	

@regression
Scenario:01. Add single user for single Organization with NowRx/PowRx 
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user on 'Customer Admin UI'
	When user on 'Add User' modal
	And user selects 'NowRx' organization
	Then 'NowRx' user roles are displayed
	And user changes to 'PowRx' 
	Then modal display 'PowRx' user roles
	And user creates account
	Then modal closes and user list is refreshed
	
