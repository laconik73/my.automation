@uat

Feature:  Referral

Scenario:01. Making a Referral to a Favorited Service
    Given 'CPT3' user is logged in
	And user chooses tab 'Patient'	
	And user chooses patient card
	And user chooses subtab 'Referrals' 
    When user chooses button 'Add Referral'
    And user selects icon 'Favorites'
	And user refers a service
	And user sends referral
	Then referral is sent
