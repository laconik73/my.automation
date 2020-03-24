Feature: Edit
	

@regression
Scenario:01.  Editing Patient Contact Information
   Given 'CPT11' user is logged in
   And user chooses tab 'Patient'
   And user chooses patient card
   When user makes a choice to 'Edit Profile'
   And user expands 'Contact Information' section
   And user edits 'Contact Information'
   Then edited contact information is displayed in patient's 'Consent'

Scenario:02. Editing Patient Demographics
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user makes a choice to 'Edit Profile'
	And user expands  patient 'Demographics' section
	And user edits patient 'Demographics'
	Then demographics are updated in patient overview

Scenario: 03. Editing Patient Basic Information
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'  
	And user chooses patient card
	When user makes a choice to 'Edit Profile'
	And user edits basic information
	Then basic information is updated in patient overview
