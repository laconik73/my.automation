@cpt_username

Feature:  Coordinated Referrals

Scenario:01.  Sending Referral via Services
   Given 'CPT' user is logged in
   When user chooses tab 'Services'
   And user searches for the organization in coordinated network
   And user click on button 'Refer'
   And user refers patient information with a note
   Then referral is made

Scenario: 02. Verify error message display for Referral Sender
Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
    And user makes referral 
	And user opens Edit Referral modal
	And user accepts referal
	Then 'error' message is displayed


