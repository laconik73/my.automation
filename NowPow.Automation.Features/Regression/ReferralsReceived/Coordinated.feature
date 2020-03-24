Feature: Coordinated
	

@regression
Scenario: 01. Verify Refferred patient is not visible until accepted 
	 Given 'CPT3' user is logged in
	 When user does not accept new referral
	 And user searches for a new referred patient
	 Then search results return no matching criteria

Scenario: 02.Verify Referred Patient is visible when accepted
	Given 'CPT3' user is logged in
	When user accepts new referral
	And user searches accepted referral
	Then new patient is created and patient card is displayed


