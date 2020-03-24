Feature: ForgotPassword
	

@smoke
Scenario:01. Verify Reset/Forgot Password functionality
	Given user is on 'CPT' login page
	When user clicks on 'Reset/Forgot Password' link
	Then reset email is sent
	And user inputs username
	And user clicks on 'Reset/Forgot Password' link
	Then reset email is sent
