Feature: TaskViewTooltip
	

@uat
@regression
Scenario: 01. Verify display of tooltip via Task View (New Referrals)
	Given 'CPT2' user is logged in	
	And user chooses Referrals Received
	And user on 'Task View' page
	And user has 'Service Outcome' not configured
	When user accepts referral 
	Then 'tooltip' is displayed next to Service Outcome field
	And user clicks on service outcome 'tooltip'
	Then tooltip display a text

Scenario: 02. Verify display of tooltip via Task View (Attendance & Outcome)
	Given 'CPT2' user is logged in	
	And user chooses Referrals Received
	And user on 'Task View' page
	When user chooses subpanel 'Attendance & Outcomes'
	And user has 'Service Outcome' not configured	
	Then 'tooltip' is displayed next to Service Outcome field
	And user clicks on service outcome 'tooltip'
	Then tooltip display a text

Scenario: 03. Verify display of tooltip via Task View (Waitlist)
	Given 'CPT2' user is logged in	
	And user chooses Referrals Received
	And user on 'Task View' page	
	When user accepts 'Waitlist' referral
	Then 'tooltip' is displayed next to Service Outcome field
	And user clicks on service outcome 'tooltip'
	Then tooltip display a text
