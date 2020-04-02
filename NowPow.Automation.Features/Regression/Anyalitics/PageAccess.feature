Feature: PageAccess

#Bug: analytics tab navigates to error page in UAT. 
#Execute test only in Stage

	
Background:
Given 'CPT11' user is logged in

@regression
Scenario:01. Accessing the Analytics page	
	When user chooses 'Analytics' tab
	Then user navigates to Analytics page
	When user chooses 'NowPow' logo from Analytics page
	Then user redirects back to 'CPT'
