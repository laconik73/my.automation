Feature: UploadModal
	

@smoke
Scenario: 01.Verify " Upload Document" modal display
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	Then 'Upload Document' modal pops up
