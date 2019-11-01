@regression

Feature: Document

Scenario:01. Verify N increases of Duplicate File Name
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads file
	And user clicks on 'Upload Document' 
	And user uploads file
	Then file is uploaded as 'Duplicate Name' and increases by '1' unit

Scenario: 02.Delete document from Patient Document Page
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user chooses 'Delete' action
	And user proceeds with 'Delete'	
	Then document is deleted

Scenario: 03. Verify "Upload Document" modal features
Given 'CPT3' user is logged in
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

Scenario: 04. Verify "Add Document" button
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds document
	And user adds another document
	Then the files display as separate lines

Scenario:05. Remove files from "Make Referral" modal
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds document
	And user adds another document
	And user deletes a document
	Then document is removed

Scenario: 06. Upload Virus Document (Tanya's machine)
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses subtab 'Referrals'
	When user chooses button 'Add Referral'
	And user refers a service
	And user adds virus document
	Then 'error' message  with a link is displayed
	And referral is not created

Scenario:07. Scan uploaded document for malware (Tanya's machine)
Given 'CPT3' user is logged in
	And user chooses tab 'Patient'
	And user chooses patient card
	And user chooses a subtab 'Documents'
	When user clicks on 'Upload Document' 
	And user uploads a virus document
	Then 'error' message  with a link is displayed
	And user uploads file with a note
	Then fie is successfully uploaded and note is displayed







