Feature: UserRoles
	

@regression
Scenario: 01.Display PowRx user roles
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user on 'Customer Admin UI'
	When user expands 'User Roles' filter
	Then filter display roles based on org license

Scenario: 02.Display PowRx Referral user roles
	Given 'CPT9' user is logged in
	And user nagivates to 'Admin' page
	And user on 'Customer Admin UI'
	When user expands 'User Roles' filter
	Then filter display roles based on org license

Scenario: 03.Display NowRx user roles
	Given 'CPT7' user is logged in
	And user is on 'Customer Admin UI'
	When user chooses 'User Roles' filter
	Then filter display roles based on org license

