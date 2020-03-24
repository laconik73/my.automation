Feature: ReferableServices
	

@smoke
Scenario: 03.Display Referable Services in Coordinated Network
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	Then modal display only referable services within the network
