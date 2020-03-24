Feature: ReferralForm
	

@smoke
Scenario: 01. Verify Send Referral Form Design via Patient page
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals' 
	When user chooses button 'Add Referral'
	And user chooses 'Refer'service
	Then referral form is displayed

Scenario: 02. Verify Send Referral Form Design via Service page
	Given 'CPT11' user is logged in
	When user chooses tab 'Services'
	And user  chooses  'Favorite Services'
	And user click on button 'Refer'
	Then referral form is displayed on Service Page
	And patient name is required to input
	And service select  filter option is displayed
