Feature: RestrictionCheckbox
	

@regression
Scenario:01. Verify Referral service restriction checkbox
	Given 'CPT' user is logged in
	When user chooses tab 'Services'
	And user  selects restricted 'Favorite Service'
	And user click on button 'Refer'	
	Then restrictions are displayed under 'Referral Partner'
	And user inputs patient name
	And the restriction checkbox displays text in red 
	And user accepts restrictions
	Then restriction text becomes black

