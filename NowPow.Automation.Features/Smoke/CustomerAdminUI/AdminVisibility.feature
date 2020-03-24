Feature: AdminVisibility
	
#create user in sls without admin role
@smoke
Scenario: 01. Verify Admin tab visibility for CommRx user
	Given 'CPT5' user is logged in
	When user does not have any admin roles
	Then user does not gain access to 'Admin' tab
