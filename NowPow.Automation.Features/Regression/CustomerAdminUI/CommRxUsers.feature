Feature: CommRxUsers
	

@regression
Scenario:01. Deactivate User (CommRx) 
	Given 'CPT5' user is logged in
	When user chooses to deactivate user
	Then success modal displayed

Scenario:02. Activate User (CommRx) 
	Given 'CPT5' user is logged in
	When user chooses to activate user
	Then success modal  is displayed

Scenario:03. Download Users CSV (CommRx) 
	Given 'CPT5' user is logged in
	When user chooses download
	Then full list of users is downloaded in csv format

Scenario:04. Resend Password for users (CommRx) 
	Given 'CPT5' user is logged in
	When user selects 'Resend Password' action
	Then confirmation modal with 'message' displays


Scenario:05. Verify CommRx "User" modal display 
	Given 'CPT5' user is logged in
	When user on 'Add User' modal
	Then modal display permission message for 'Service search' and 'eRx Creation'

Scenario:06.Display CommRx user roles
	Given 'CPT5' user is logged in
	When user expands 'User Roles' filter
	Then filter display roles based on org license

Scenario:07. Add single user for CommRx
	Given 'CPT5' user is logged in
	When user on 'Add User' modal
	And user creates account
	Then modal display a text
	And user closes modal 
	Then user list is refreshed



