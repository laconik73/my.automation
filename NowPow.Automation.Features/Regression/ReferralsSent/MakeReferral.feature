Feature: MakeReferral
	

@regression
Scenario: 01.Making a Referral via eRx page
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user chooses 'View eRx' button
	And user makes referral
	Then referral is sent
	And user chooses 'Back to Patient' button
	And user chooses subtab 'Referrals'
	Then new referral is listed on patient referrals

Scenario: 02. Send Coordinated Referral via eRx
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user chooses 'View eRx' button 
	And user makes coordinated referral
	Then service marked as 'Referral Sent'
