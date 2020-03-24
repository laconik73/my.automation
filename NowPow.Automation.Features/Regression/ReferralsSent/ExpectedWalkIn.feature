Feature: ExpectedWalkIn
	
@regression
Scenario:01. Adding Referral 'Expected Walk-In' via Patient Referrals 
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals' 
	When user opens 'Edit Referral' modal for an existing appointment
	And user saves referral with 'expected walk-in'
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction
