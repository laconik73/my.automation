Feature: ImportPatient
	

@smoke
Scenario: 01. Importing a Patient
	Given 'CPT8' user is logged in
	And user is on 'Admin'page 
	When user imports new patient
	Then page lists a successful patient upload
	And user searches for newly uploaded patient
	Then new patient card is displayed