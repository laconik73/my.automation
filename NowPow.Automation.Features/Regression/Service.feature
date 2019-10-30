@regression
Feature:  Services

Scenario:01. Verify Service search filters
    Given 'CPT' user is logged in
	When user chooses tab 'Services'
	And user searches for a 'Service'
	And user applies filters
	And user changes radius
	And user changes zip code
	And user changes 'Sort by' options
	Then the search results are updated

Scenario:02. Favoriting a Service
Given 'CPT' user is logged in
	When user chooses tab 'Services'
	And user searches for a 'Service'
	And user favorites the service
	Then service is favorited and added
	And user unfavorites the service
	Then service is unfavorited and removed


