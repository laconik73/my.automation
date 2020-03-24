Feature: UploadVirusDoc
	

@smoke
Scenario:01. Error message display for virus document 
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads a virus document
	Then 'error' message  with a link is displayed
