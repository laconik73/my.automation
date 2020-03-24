Feature: SendPassword
	

@smoke
Scenario: 01. Sending password reset to an Org user
	Given 'SLS' user is logged in
	And user on 'Organization Management' tab
	When new user is created
	Then 'User Active' checkbox is checked 
	And 'Send Create Password Email?' checkbox displays
	And user chooses to reset email password
	Then email for password reset is sent
