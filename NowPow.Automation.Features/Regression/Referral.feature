@regression

Feature:  Referral

Scenario:01. Sending message to Referral Taker via Patient Referral Page
    Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user searches for a Patient
	And user chooses patient card
	And user chooses subtab 'Referrals' 
	When user sends a message to a referral taker
	Then message is sent
	And user navigates back to patient's referral
	Then all patient referrals are displayed

Scenario:02. Sending message to Referral Maker via Task View page
	Given 'CPT2' user is logged in
	And user on 'Task View' page
	When user sends a message to a referral maker
	Then message is sent

Scenario: 03. Send Coordinated Referral via eRx
Given 'CPT3' user is logged in
And user chooses patient card
When user chooses 'View eRx' button 
#When user selects button 'Build New eRx'
#And user adds condition 
And user makes coordinated referral
Then service marked as 'Referral Sent'

Scenario:04. Making a Referral to a Favorited Service
    Given 'CPT3' user is logged in
	And user chooses tab 'Patient'	
	And user chooses patient card
	And user chooses subtab 'Referrals' 
    When user chooses button 'Add Referral'
    And user selects icon 'Favorites'
	And user refers a service
	And user sends referral
	Then referral is sent





    
