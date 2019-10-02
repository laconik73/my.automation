@cpt_username

Feature:  Referral

Scenario:01. Making a Referral via Patient Referral Page
    Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses subtab 'Referrals' 
    When user chooses button 'Add Referral'
    And user sends referral with a note
    Then new referral is listed

Scenario: Verify Referral Service Received dropdown appearance
Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user opens Edit Referral modal
	And user edits opened referral info
	Then referral info should be saved

	And user selects referral's contact status as 'Contacted' 
	Then 'Service Received' dropdown is displayed and is editable
	And user selects referrals's contact status as 'Other'
	Then 'Service Received' dropdown is displayed and is editable
	When user selects referral's contact status as 'Unable to Contact'
	Then 'Service Received' dropdown is displayed, set to No, and is not editable
	When the user selects referral's contact status as 'Attempted Contact'
	Then 'Service Received' dropdown is not displayed




	

	


	

	








	

	

