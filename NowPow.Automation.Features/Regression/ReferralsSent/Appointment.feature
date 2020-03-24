Feature: Appointment
	
@regression
Scenario: 01.Adding multiple Referral appointments
	Given 'CPT12' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user opens 'Edit Referral' modal for an existing appointment
	And user saves referral with multiple appointments
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction

Scenario: 02. Editing Referral appointment date/time via Patient Referrals 
	Given 'CPT12' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals' 
	When user opens 'Edit Referral' modal for an existing appointment
	And user edits an appointment
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction 

Scenario: 03.Editing multiple Referral appointment statuses via Patient Referrals 
	Given 'CPT12' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	And user chooses subtab 'Referrals' 
	When user opens 'Edit Referral' modal for an existing appointment
	And user edits multiple appointments
	And user edits statuses
	And user saves edited statuses with a note
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction


Scenario:04.Deleting multiple Referral appointments
	Given 'CPT12' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user opens 'Edit Referral' modal for an existing appointment
	And user deletes  multiple appointments
	Then 'Last Update' display an updated appointment status
	And 'Referral History' display an updated appointment interaction


