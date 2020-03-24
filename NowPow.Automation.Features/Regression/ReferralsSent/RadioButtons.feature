Feature: RadioButtons
	

@regression
Scenario: 01.Verify radio buttons in Edit Referral Modal
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user opens 'Edit Referral' modal for an existing appointment
	And user selects contact status 'Attempt to Contact'
	Then radio buttons do not display
	And user sets contact status to 'Unable to Contact'
	Then radio buttons do not display
	And user chooses contact status 'Other'
	Then radio buttons do not display
	And user selects 'Contacted' status
	Then radio buttons are displayed
	And user double clicks 'Client Declined Service' radio button
	Then radio button is selected and 'deselected'
	And user double clisks 'Ineligible for this service' radio button
	Then radio buttons are selected and 'deselected'
	And user clicks on 'each' radio button
	Then one radio button is deselected and another is selected

Scenario: 02.Verify 'Client Declined Service' radio button 
	Given 'CPT11' user is logged in
	And user selects 'Referrals Sent' tab
	When user selects 'Client Declined Service' radio button
	Then 'Add Appt' and 'Add Walk-In' greyed out
	And service received autofills to 'No'
	And service outcome autofills to 'Unsuccessful'
	And action button displays 'Close Referral'
	

Scenario: 03.Verify 'Ineligible for this Service' radio button
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user opens 'Edit Referral' modal for an existing appointment
	And user sets contact status as 'Contacted'
	Then radio buttons are displayed
	And user chooses 'Ineligible for this Service' radio button
	Then 'Add Appt' and 'Add Walk-In' greyed out
	And service received autofills to 'No'
	And service outcome autofills to 'Unsuccessful'
	And action button displays 'Close Referral'




