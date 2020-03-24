Feature: AddRole
	

@smoke
Scenario:01. Add User Management role
	Given 'SLS' user is logged in
	And user on 'Organization Management' tab
	When user opens 'Edit Contact' modal
	Then 'Admin-User Management' role is visible
	And user selects 'admin' and 'org' roles
	Then 'CPT' user is able to access 'User Management' side panel


