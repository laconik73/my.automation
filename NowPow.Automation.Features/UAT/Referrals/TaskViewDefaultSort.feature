Feature: TaskViewDefaultSort
	

@uat
@regression
Scenario: 01. Verify Task View New Referrals default sorting
	Given 'CPT2' user is logged in
	And user chooses Referrals Received
	And user on 'Task View' page	
	When user verifies 'New Referrals' subpanel
	Then not updated referrals display on the top fo the list
	And 'accepted' and not 'contacted' display next 
	And 'accepted' and 'contacted' display last on the page
