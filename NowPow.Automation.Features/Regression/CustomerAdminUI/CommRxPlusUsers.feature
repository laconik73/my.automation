Feature: CommRxPlusUsers
	
Background: 
Given 'CPT6' user is logged in

@regression

Scenario:01.Display CommRx+ user roles	
	When user expands 'User Roles' filter
	Then filter display roles based on org license
