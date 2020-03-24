Feature: CommRxPlusUsers
	

@regression
Scenario:01. Verify CommRx+ "User" modal display
	Given 'CPT6' user is logged in
	When user on 'Add User' modal
	Then modal display permission message for 'Service search' and 'eRx Creation'
	And optional permission checkbox 'Receive Tracked Referrals'

Scenario:02.Display CommRx+ user roles
	Given 'CPT6' user is logged in
	When user expands 'User Roles' filter
	Then filter display roles based on org license
