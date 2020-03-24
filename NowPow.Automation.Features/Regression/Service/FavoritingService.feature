Feature: FavoritingService
	

@regression
Scenario:01. Favoriting a Service
	Given 'CPT11' user is logged in
	When user chooses tab 'Services'
	And user searches for a 'Service'
	And user favorites the service
	Then service is favorited and added
	And user unfavorites the service
	Then service is unfavorited and removed
