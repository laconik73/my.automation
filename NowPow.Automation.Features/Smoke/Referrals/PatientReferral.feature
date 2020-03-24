Feature: PatientReferral
	

@smoke
Scenario:01. Making a Referral via Patient Referral Page
    Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals' 
    When user chooses button 'Add Referral'
    And user sends referral with a note
    Then new referral is listed