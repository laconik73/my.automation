Feature: PageAccess
	

@regression
Scenario:01. Accessing the Analytics page
	Given 'CPT11' user is logged in
	When user chooses 'Analytics' tab
	Then user navigates to Analytics page
	And user chooses 'NowPow' logo from Analytics page
	Then user redirects back to 'CPT'
