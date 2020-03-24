Feature: TableSorting
	

@regression
Scenario: 01. Verify Documents table sorting
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'	
	When user clicks on 'Document Name' column
	Then documents are displayed in Ascending order
	And user chooses 'Upload Date' column
	Then dates are displayed in Ascending order

Scenario: 02. Verify Default Documents table sorting
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads file
	Then documents are sorted by Upload Date in Descending order
	And user refreshes page
	Then documents are sorted by Upload Date in Descending order

