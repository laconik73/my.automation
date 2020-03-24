Feature: ServiceOutcomeDetails
	

@uat
@regression
Scenario: 19. Removal of asterisk on Service Outcome Details field
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	And user is on 'Edit Referral' modal
	When 'service received' and 'service outcome' are filled out
	And user selects any radio button
	Then asterisk is removed from 'Service Outcome Details' field
