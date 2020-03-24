Feature: AdditionalField
	

@regression
Scenario: 01. Support Additional Fields on Referral Form
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches patient card
	And user clisks on patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
    And user selects icon 'Favorites'
	And user refers a service	
	Then 'Additional Information' requested by partner is visible
	And user leaves required fields without a response
	Then user unable to send a referral
	And user responses to required fields
	Then responses have to character limit

