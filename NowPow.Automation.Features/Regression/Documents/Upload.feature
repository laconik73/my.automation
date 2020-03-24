Feature: Upload
	
@regression
Scenario: 01. Verify "Upload Document" modal features
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user chooses one file to upload
	Then 'Upload' button is enabled
	And a user chooses 'Cancel' button
	Then modal is closed
	And user clicks on 'Upload Document' again
	Then any data entered on the previous modal is cleared

Scenario:02. Verify N increases of Duplicate File Name
	Given 'CPT' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads file
	And user clicks on 'Upload Document' 
	And user uploads file
	Then file is uploaded as 'Duplicate Name' and increases by '1' unit





