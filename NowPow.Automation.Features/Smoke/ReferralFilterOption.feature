@cpt_username
@smoke

Feature: Referral Filter Options

Scenario:01. Verify  filter options via Patient Referral Page
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses 'My Referrals' from 'User Level' dropdown menu
	Then dropdown menu displays options

	#Scenario:02. Verify checked items via Patient Referral Page
	#Given 'CPT' user is logged in
	#And user chooses tab 'Patient'
	#And user chooses patient card
	#And user chooses subtab 'Referrals'
	#When user chooses 'All Referrals' from 'Status Filter' dropdown menu
	#Then dropdown menu displays options
