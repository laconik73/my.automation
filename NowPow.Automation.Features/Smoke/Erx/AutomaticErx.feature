Feature: AutomaticErx
	

@smoke
Scenario:01. Creating Automatic eRx via Patient Profile
	Given 'CPT11' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	When user makes a choice to 'Edit Profile'
	And user inputs address into 'Contact Information' section
	And user adds condition into 'Conditions' section
	Then automatic eRx is generated
