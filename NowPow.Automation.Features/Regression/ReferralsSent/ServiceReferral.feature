Feature: ServiceReferral
	

@regression
Scenario: 01.Verify Error Message display on Referral form (same service for same patient)
	Given 'CPT11' user is logged in
	When user chooses tab 'Services'
	And user  chooses  'Favorite Services'
	And user click on button 'Refer'
	And user inputs new patient name that was referred to the same service
	Then error message is displayed
	And user selects different service for the same organization
	Then error message disappears

Scenario:02. Making a Referral to a Favorited Service
    Given 'CPT' user is logged in
	And user chooses tab 'Patient'	
	And user chooses patient card
	And user chooses subtab 'Referrals' 
    When user chooses button 'Add Referral'
    And user selects icon 'Favorites'
	And user refers a service
	And user sends referral
	Then referral is sent