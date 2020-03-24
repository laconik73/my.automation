Feature: PatientSearch
	

@uat
@regression
Scenario: 01. Verify Task View patient search
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	And user on 'Task View' page	
	When user searches for a 'patient' across subpanels
	Then page displays matching searched names

