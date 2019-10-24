﻿@regression

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




    