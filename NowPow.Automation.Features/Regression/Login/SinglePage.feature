Feature: SinglePage
	

@regression
Scenario:01. Verify Single-page application functionality
	Given 'CPT11' user is logged in
	When 'CPT11' user is logged in a new window
	Then 'CPT11' user is logged out from first window
