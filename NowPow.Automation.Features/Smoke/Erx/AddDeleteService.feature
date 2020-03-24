Feature: Add/Delete Service
	

@smoke
Scenario: 01.Adding a Service on an Erx
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user chooses 'View eRx' button
	And user chooses to 'Edit' eRx
	And user chooses 'Add' service
	And user selects a service
	Then new service saved on an Erx

Scenario: 02. Deleting a Service on an Erx
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user chooses 'View eRx' button
	And user chooses to 'Edit' eRx
	And user removes services from an Erx
	Then service is removed from an Erx

