Feature: AlternativeService
	
@regression
Scenario: 01.Adding a alternate service to an eRx
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user chooses 'View eRx' button 
	And user chooses to 'Edit' eRx
	And user adds an alternative service
	Then alternative service is displayed on an eRx
