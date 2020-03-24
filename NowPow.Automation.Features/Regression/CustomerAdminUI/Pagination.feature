Feature: Pagination
	

@regression
Scenario:01. Users Table Paging (PowRx)
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user on 'Customer Admin UI'
	When user pages through the result set
	Then page results are updated
