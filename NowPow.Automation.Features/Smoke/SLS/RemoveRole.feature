Feature: RemoveRole
	

@smoke
Scenario:01. Remove User Management role
	Given 'SLS' user is logged in
	And user on 'Organization Management' tab
	When user opens 'Edit Contact' modal
	Then 'Admin-User Management' role is visible
	And user disselects 'admin' and 'org' roles
	Then roles are disselected
