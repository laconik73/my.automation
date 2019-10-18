@cpt_username
@smoke

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

Scenario:02. Verify Contact Status Display
Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user opens Edit Referral modal
	And user edits opened referral info
	Then referral info should be saved

Scenario: 03.Making a Referral via eRx page
Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	When user chooses 'View eRx' button
	And user makes referral
	Then referral is sent
	And user chooses 'Back to Patient' button
	And user chooses subtab 'Referrals'
	Then new referral is listed on patient referrals






	




	

	


	

	








	

	

