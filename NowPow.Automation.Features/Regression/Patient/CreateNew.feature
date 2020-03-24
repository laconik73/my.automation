Feature: CreateNew
	

@regression
Scenario:01. Creating New Profile
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses 'Create New Profile'
	When user navigates to patient's section
	And user inputs 'Basic Information'
	And user chooses 'Save and Create'
	Then New Profile is created
