Feature: Search
	
@regression
Scenario: 01.Verify Patient Search by MRN
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	When user searches patient by 'MRN'
	Then patient matching mrn is dispayed

Scenario: 02.Verify invalid name
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	When user input invalid name
	Then no results are dispayed
