Feature: DocumentSubtab
	

@smoke
Scenario: 01. Verify "Documents" subtab visibility
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user is on Patient's 'Overview' page
	Then 'Documents' subtab is displayed
