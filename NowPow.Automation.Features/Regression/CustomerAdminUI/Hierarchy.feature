Feature: Hierarchy
	
@regression
Scenario: 01. Organization Administration Hierarchy for NowRx
	Given 'CPT7' user is logged in
	And user is on 'Customer Admin UI'
	When 'Organization Admin' chooose to view administration hierarchy
	Then hierarchy of the logged in organization only is displayed

Scenario: 02. Organization Administration Hierarchy for PowRx
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user on 'Customer Admin UI'
	When 'Network Admin' views administration hierarchy
	Then hierarchy of the entire network tree is displayed

Scenario: 03. Organization Administration Hierarchy
	Given 'CPT2' user is logged in
	When user does not have 'Network/Enterprise/Organization Admin'
	Then user does not have an Organization Administration hierarchy

Scenario: 04. Organization Administration Hierarchy for CommRx
	Given 'CPT5' user is logged in
	When 'Enterprise Admin' views administration hierarchy
	Then hierarchy of the nearest Enterprise to the Organization they are associated to is displayed
