Feature: Add User Modal (PowRx license)

Background: 
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user chooses 'User Management' subpanel
	And user is on 'Add User' modal

@regression
Scenario Outline:Check for existing user
	When user adds email '<email>'	
	And user adds username '<username>'
	Then user should see error message  

	Examples: 
	   | email          | username        |
	   | bubu9@kuku.com | bubu9@kuku.com  |
	   | kuku@kuku.com  | kuku@kuku.com   |
	   | bubu9@kuku.com | bubu+9@kuku.com | 

	   #Last data provider shall fail. No error message shall display.












	
	
